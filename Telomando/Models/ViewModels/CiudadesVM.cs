using Microsoft.AspNetCore.Mvc.Rendering;
namespace Telomando.Models.ViewModels
{
    public class CiudadesVM
    {
        public Ciudade oCiudad { get; set; }

        public List<SelectListItem> oListaMunicipios { get; set; }
    }
}
