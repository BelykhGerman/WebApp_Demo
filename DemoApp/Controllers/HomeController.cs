using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Core.Controllers {

    public class HomeController : Controller {

        [Route ( "" )]
        [HttpGet]
        public IActionResult Index() {
            return View ();
        }
    }
}