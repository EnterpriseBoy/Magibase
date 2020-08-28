using MagiApi.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MagiApi.Controllers
{

    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/test")]
        public ContentResult Test()
        {
            return Content("asd");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/register")]
        public async Task<ContentResult> Register([FromBody] Login userAccess)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = userAccess.Username };
                var result = await _userManager.CreateAsync(user, userAccess.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Content("well done");
                }

                var errorsors = "Error are:";
                foreach (var error in result.Errors)
                {
                    errorsors = errorsors + " " + error.Description;
                }
                return Content(errorsors);
            }

            return Content("Feck off");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/login")]
        public async Task<IActionResult> Login([FromBody] Login credentials)
        {

            if (!ModelState.IsValid || credentials == null)
            {
                return Unauthorized();
            }

            var identityUser = await _userManager.FindByNameAsync(credentials.Username);
            if (identityUser == null)
            {
                return Unauthorized();
            }

            var result = _userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, credentials.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return Unauthorized();
            }

            var claims = new List<Claim>
            {
                //new Claim(ClaimTypes.Email, identityUser.Email),
                new Claim(ClaimTypes.Name, identityUser.UserName)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            return Content("Well done you are logged in");
        }

    }
}
