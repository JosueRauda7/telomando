using Microsoft.AspNetCore.Mvc.Rendering;
namespace Telomando.Models.ViewModels
{
    public class ClienteVM
    {
        public Cliente oCliente { get; set; }

        public List<SelectListItem> oListaUsuario { get; set; }

        public List<SelectListItem> oListaTipoCliente { get; set; }
    }
}
