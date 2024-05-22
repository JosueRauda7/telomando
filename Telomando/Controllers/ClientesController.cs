using Microsoft.AspNetCore.Mvc;

namespace Telomando.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
