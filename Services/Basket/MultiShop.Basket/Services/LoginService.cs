namespace MultiShop.Basket.Services
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public string GetUserID => _httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
