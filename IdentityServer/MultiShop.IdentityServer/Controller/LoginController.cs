using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.DTOs;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDTO userLoginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginDTO.Email, userLoginDTO.Password, false, false);
            if (result.Succeeded)
            {
                return Ok("Logged in successfully");
            }
            else
            {
                return BadRequest("User not found or somehow couldn't log in");
            }
        }
    }
}