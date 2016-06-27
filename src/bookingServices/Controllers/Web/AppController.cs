using Microsoft.AspNet.Mvc;

namespace bookingServices.Controllers.Web
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
