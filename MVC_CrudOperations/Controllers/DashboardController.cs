using Microsoft.AspNetCore.Mvc;

namespace MVC_CrudOperations.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
