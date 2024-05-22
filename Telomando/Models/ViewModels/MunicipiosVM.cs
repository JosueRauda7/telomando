using Microsoft.AspNetCore.Mvc.Rendering;
namespace Telomando.Models.ViewModels
{
    public class MunicipiosVM
    {
        public Municipio oMunicipio { get; set; }

        public List<SelectListItem> oListaDepartamento { get; set; }
    }
}
