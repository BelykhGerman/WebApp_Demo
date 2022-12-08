using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Core.Controllers {

    public class HomeController : Controller {

        [Route ( "" )]
        [HttpGet]
        public async Task<IActionResult> Index() {
            return View ();
        }
    }
}