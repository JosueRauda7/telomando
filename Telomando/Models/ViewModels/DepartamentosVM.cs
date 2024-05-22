using Microsoft.AspNetCore.Mvc.Rendering;
namespace Telomando.Models.ViewModels
{
    public class DepartamentosVM
    {
        public Departamento oDepartamento { get; set; }

        public List<SelectListItem> oListaPaise { get; set; }

      
    }
}
