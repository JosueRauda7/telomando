using Microsoft.AspNetCore.Mvc.Rendering;
namespace Telomando.Models.ViewModels
{
    public class BodegaVM
    {
        public Bodega oBodega { get; set; }

        public List<SelectListItem> oListaSucursal { get; set; }

        public List<SelectListItem> oListaTipoBodega { get; set; }
    }
}
