using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers {

    public class ErrorController : Controller {
        private readonly ILogger<ErrorController> logger;

        public ErrorController( ILogger<ErrorController> logger ) {
            this.logger = logger;
        }

        [Route ( "Error/{statusCode}" )]
        public IActionResult HttpStatusCodeHandler( int statusCode ) {
            switch(statusCode) {
                case 400:
                    ViewBag.ErrorMessage = HttpContext.Response.Headers["ErrorMessage"].ToString () ?? "Bad request";
                    break;

                case 401:
                    ViewBag.ErrorMessage = HttpContext.Response.Headers["ErrorMessage"].ToString () ?? "Not authorized";
                    break;

                case 404:
                    ViewBag.ErrorMessage = HttpContext.Response.Headers["ErrorMessage"].ToString () ?? "Couldn't find source";
                    break;

                default:
                    ViewBag.ErrorMessage = HttpContext.Response.Headers["ErrorMessage"].ToString () ?? "Not handle";
                    break;
            }
            return View ( "Error" );
        }

        [Route ( "Error" )]
        [AllowAnonymous]
        public IActionResult ExceptionHandler() {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature> ();
            if(exceptionDetails != null) {
                logger.LogError ( $"The path\n {exceptionDetails.Path}\n threw exception {exceptionDetails.Error}" );
            }
            return View ( "Error" );
        }
    }
}