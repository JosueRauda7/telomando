using Microsoft.AspNetCore.Mvc;

namespace Telomando.Controllers
{
    public class UsuarioInfo : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
