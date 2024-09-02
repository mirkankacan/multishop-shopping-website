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

        public IdentityService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, IOptions<ClientSettings> clientSettings /*,IOptions<ServiceApiSettings> serviceApiSettings*/)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _clientSettings = clientSettings.Value;
            //_serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> SignIn(CreateLoginDTO createLoginDTO)
        {
            try
            {
                var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
                {
                    Address = "http://localhost:5001",
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

                var tokenResponse = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

                if (tokenResponse.IsError)
                {
                    return false;
                }
                var userInfoRequest = new UserInfoRequest
                {
                    Token = tokenResponse.AccessToken,
                    Address = discoveryEndPoint.UserInfoEndpoint
                };
                var userInfoResponse = await _httpClient.GetUserInfoAsync(userInfoRequest);

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
                // Log the exception and handle appropriately
                throw new Exception($"Sign-in failed: {ex.Message}", ex);
            }
        }

        //public async Task<bool> GetRefreshToken()
        //{
        //    try
        //    {
        //        var userClaims = _httpContextAccessor.HttpContext.User.Claims;

        // var roleClaim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role); if (roleClaim
        // == null) { throw new Exception("User role not found."); } string clientId; string clientSecret;

        // // Determine client configuration based on user roles if (roleClaim.Value == "Admin") {
        // clientId = _clientSettings.MultiShopAdminClient.ClientID; clientSecret =
        // _clientSettings.MultiShopAdminClient.ClientSecret; } else { clientId =
        // _clientSettings.OtomarRegisteredUserClient.ClientId; clientSecret =
        // _clientSettings.OtomarRegisteredUserClient.ClientSecret; } if
        // (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret)) { throw new
        // Exception("Client ID or Client Secret is not configured."); } var discoveryEndPoint =
        // await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest { Address =
        // _serviceApiSettings.IdentityServerUrl, Policy = new DiscoveryPolicy { RequireHttps =
        // false } }); if (discoveryEndPoint.IsError) { // Handle discovery endpoint error return
        // false; }

        // var refreshToken = await
        // _httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);
        // if (string.IsNullOrEmpty(refreshToken)) { return false; }

        // RefreshTokenRequest refreshTokenRequest = new() { ClientId = clientId, ClientSecret =
        // clientSecret, RefreshToken = refreshToken, Address = discoveryEndPoint.TokenEndpoint };

        // var tokenResponse = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

        // if (tokenResponse.IsError) { return false; } var expiresAt = DateTime.UtcNow.AddSeconds(tokenResponse.ExpiresIn);

        // var authenticationTokens = new List<AuthenticationToken> { new AuthenticationToken { Name
        // = OpenIdConnectParameterNames.AccessToken, Value = tokenResponse.AccessToken }, new
        // AuthenticationToken { Name = OpenIdConnectParameterNames.RefreshToken, Value =
        // tokenResponse.RefreshToken }, new AuthenticationToken { Name = "expires_at", Value =
        // expiresAt.ToString("o", System.Globalization.CultureInfo.InvariantCulture) } }; var
        // authenticateResult = await _httpContextAccessor.HttpContext.AuthenticateAsync();

        // if (authenticateResult.Succeeded) { var properties = authenticateResult.Properties; properties.StoreTokens(authenticationTokens);

        // await
        // _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
        // authenticateResult.Principal, properties);

        // return true; }

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
    }
}