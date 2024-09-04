using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DTOs.IdentityDTOs.LoginDTOs;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDTO createLoginDTO, CancellationToken cancellationToken)
        {
            var loginStatus = await _identityService.SignIn(createLoginDTO, cancellationToken);
            switch (loginStatus)
            {
                case true:
                    return RedirectToAction("Index", "User");
                    break;

                case false:
                    return View();
                    break;

                default:
                    return View();
                    break;
            }
        }
    }
}