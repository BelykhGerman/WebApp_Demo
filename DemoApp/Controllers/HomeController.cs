using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers {

    public class HomeController : Controller {

        [Route ( "" )]
        [HttpGet]
        public async Task<IActionResult> Index() {
            return View ();
        }
    }
}