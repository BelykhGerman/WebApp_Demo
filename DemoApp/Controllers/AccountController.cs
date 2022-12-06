using DemoApp.Models;
using DemoApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers {

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

    }
}