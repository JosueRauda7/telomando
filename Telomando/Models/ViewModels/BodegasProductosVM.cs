using Microsoft.AspNetCore.Mvc.Rendering;

namespace Telomando.Models.ViewModels
{
    public class BodegasProductosVM
    {
        public BodegaProducto oBodegaProducto { get; set; }

        public List<SelectListItem> oListaBodegas { get; set; }

        public List<SelectListItem> oListaProductos { get; set; }
    }
}
