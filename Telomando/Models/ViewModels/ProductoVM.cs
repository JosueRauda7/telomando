using Microsoft.AspNetCore.Mvc.Rendering;

namespace Telomando.Models.ViewModels
{
    public class ProductoVM
    {
        public Producto oProducto { get; set; }

        public List<SelectListItem> oListaMarca { get; set; }
    }
}
