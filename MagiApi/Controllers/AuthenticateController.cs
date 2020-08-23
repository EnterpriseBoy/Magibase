using MagiApi.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MagiApi.Controllers
{

    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthenticateController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //[HttpGet("{id}", Name = "GetEvent")]
        [HttpGet]
        [Route("api/get")]
        public ContentResult CheckThisWorks()
        {
            return Content("This works");
        }

        [HttpPost]
        [Route("api/register")]
        public async Task<ContentResult> Register([FromBody] UserAccess userAccess)
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
        [Route("api/login")]
        public async Task<ContentResult> Login([FromBody] UserAccess userAccess)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userAccess.Username,userAccess.Password,false,false);

                if (result.Succeeded)
                {
                    return Content("you are signed in");
                }

                return Content("login Failed");
            }
            return Content("Feck off");
        }

    }
}
