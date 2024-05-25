using Microsoft.AspNetCore.Mvc.Rendering;
namespace Telomando.Models.ViewModels
{
    public class MarcaTransporteVM
    {
        public MarcaTransporte oMarcaTransporte { get; set; }

        public List<SelectListItem> oListaModeloTransporte { get; set; }
    }
}
