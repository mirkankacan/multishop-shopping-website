using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MultiShop.DTOLayer.DTOs.IdentityDTOs.LoginDTOs;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;
using System.Security.Claims;

namespace MultiShop.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClientSettings _clientSettings;
        private readonly ServiceApiSettings _serviceApiSettings;

        public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IOptions<ClientSettings> clientSettings, IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> SignIn(CreateLoginDTO createLoginDTO, CancellationToken cancellationToken)
        {
            try
            {
                var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
                {
                    Address = _serviceApiSettings.IdentityServerUrl,
                    Policy = new DiscoveryPolicy
                    {
                        RequireHttps = false
                    }
                });

                if (discoveryEndPoint.IsError)
                {
                    throw new Exception($"Error retrieving discovery document: {discoveryEndPoint.Error}");
                }

                var passwordTokenRequest = new PasswordTokenRequest
                {
                    ClientId = _clientSettings.MultiShopManagerClient.ClientID,
                    ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                    UserName = createLoginDTO.Email,
                    Password = createLoginDTO.Password,
                    Address = discoveryEndPoint.TokenEndpoint,
                };

                var tokenResponse = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest, cancellationToken);

                if (tokenResponse.IsError)
                {
                    return false;
                }
                var userInfoRequest = new UserInfoRequest
                {
                    Token = tokenResponse.AccessToken,
                    Address = discoveryEndPoint.UserInfoEndpoint
                };
                var userInfoResponse = await _httpClient.GetUserInfoAsync(userInfoRequest, cancellationToken);

                if (userInfoResponse.IsError)
                {
                    return false;
                }
                var expiresAt = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn);

                var authenticationProperties = new AuthenticationProperties();
                authenticationProperties.StoreTokens(new List<AuthenticationToken>
                {
                    new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.AccessToken,
                        Value = tokenResponse.AccessToken
                    },
                    new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.RefreshToken,
                        Value = tokenResponse.RefreshToken
                    },
                     new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.ExpiresIn,
                        Value = expiresAt.ToString("o", System.Globalization.CultureInfo.InvariantCulture)
                    }
                });

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(userInfoResponse.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                authenticationProperties.IsPersistent = createLoginDTO.IsPersistent;

                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Sign in failed: {ex.Message}", ex);
            }
        }

        public async Task<bool> GetRefreshToken(CancellationToken cancellationToken)
        {
            try
            {
                var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
                {
                    Address = _serviceApiSettings.IdentityServerUrl,
                    Policy = new DiscoveryPolicy
                    {
                        RequireHttps = false
                    }
                });

                if (discoveryEndPoint.IsError)
                {
                    throw new Exception($"Error retrieving discovery document: {discoveryEndPoint.Error}");
                }

                var refreshToken = await _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

                if (refreshToken == null)
                {
                    return false;
                }
                RefreshTokenRequest refreshTokenRequest = new()
                {
                    ClientId = _clientSettings.MultiShopManagerClient.ClientID,
                    ClientSecret = _clientSettings.MultiShopManagerClient.ClientSecret,
                    RefreshToken = refreshToken,
                    Address = discoveryEndPoint.TokenEndpoint,
                };

                var tokenByRefreshToken = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest, cancellationToken);
                if (tokenByRefreshToken.IsError)
                {
                    return false;
                }
                var expiresAt = DateTime.UtcNow.AddSeconds(tokenByRefreshToken.ExpiresIn);

                var authToken = new List<AuthenticationToken>()
                {
                      new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.AccessToken,
                        Value = tokenByRefreshToken.AccessToken
                    },
                    new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.RefreshToken,
                        Value = tokenByRefreshToken.RefreshToken
                    },
                     new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.ExpiresIn,
                        Value = expiresAt.ToString("o", System.Globalization.CultureInfo.InvariantCulture)
                    }
                };

                var result = await _httpContextAccessor.HttpContext.AuthenticateAsync();
                var properties = result.Properties;
                properties.StoreTokens(authToken);
                await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, properties);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Token refreshing failed: {ex.Message}", ex);
            }
        }
    }
}