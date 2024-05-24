using Microsoft.AspNetCore.Mvc.Rendering;

namespace Telomando.Models.ViewModels
{
    public class DireccionesVM
    {
        public Direccione oDirecciones { get; set; }

        public List<SelectListItem> oListaCiudades { get; set; }
        public List<SelectListItem> oListaSucursales { get; set; }
        public List<SelectListItem> oListaUsuarios { get; set; }
    }
}
