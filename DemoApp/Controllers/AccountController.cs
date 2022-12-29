using DemoApp.Core.DAL;
using DemoApp.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Core.Controllers {

    public class AccountController : Controller {
        private ApplicationContext DataBase { get; }
        private UserManager<IdentityUser> UserManager { get; }
        private SignInManager<IdentityUser> SignInManager { get; }

        public AccountController(
            ApplicationContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager ) {
            DataBase = context ?? throw new ArgumentNullException ( nameof ( context ) );
            UserManager = userManager ?? throw new ArgumentNullException ( nameof ( userManager ) );
            SignInManager = signInManager ?? throw new ArgumentNullException ( nameof ( signInManager ) );
        }

        #region Register

        [Route ( "{controller}/Register" )]
        [HttpGet]
        public IActionResult Register() => View ();

        [Route ( "{controller}/Register" )]
        [HttpPost]
        public async Task<IActionResult> Register( RegisterViewModel model ) {
            if(ModelState.IsValid) {
                IdentityUser identityUser = new () { UserName = model.Email, Email = model.Email };

                var result = await UserManager.CreateAsync ( identityUser, model.Password );

                if(result.Succeeded) {
                    await SignInManager.SignInAsync ( identityUser, isPersistent: false );
                    return RedirectToAction ( "index", "home" );
                }

                foreach(var error in result.Errors) {
                    ModelState.AddModelError ( "", error.Description );
                }
            }
            return View ( model );
        }

        #endregion Register

        #region Login/Logout

        [Route ( "{controller}/Logout" )]
        [HttpGet]
        public async Task<IActionResult> Logout() {
            await SignInManager.SignOutAsync ();
            return RedirectToAction ( "index", "home" );
        }

        [Route ( "{controller}/Login" )]
        [HttpGet]
        public IActionResult Login() {
            return View ();
        }

        [Route ( "{controller}/Login" )]
        [HttpPost]
        public async Task<IActionResult> Login( LoginViewModel model ) {
            if(ModelState.IsValid) {
                var result = await SignInManager.PasswordSignInAsync ( model.Email, model.Password, model.RememberMe, false );
                if(result.Succeeded) {
                    return RedirectToAction ( "index", "home" );
                }
                ModelState.AddModelError ( string.Empty, "Invalid login attempt" );
            }
            return View ( model );
        }

        #endregion Login/Logout
    }
}