using Microsoft.AspNetCore.Mvc.Rendering;
namespace Telomando.Models.ViewModels
{
    public class SubCategoriasVM
    {
        public SubCategoria oSubCategoria { get; set; }

        public List<SelectListItem> oListaCategoria { get; set; }
    }
}
