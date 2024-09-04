using MultiShop.DTOLayer.DTOs.IdentityDTOs.LoginDTOs;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(CreateLoginDTO createLoginDTO, CancellationToken cancellationToken);

        Task<bool> GetRefreshToken(CancellationToken cancellationToken);
    }
}