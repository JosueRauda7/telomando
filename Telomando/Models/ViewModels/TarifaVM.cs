using Microsoft.AspNetCore.Mvc.Rendering;

namespace Telomando.Models.ViewModels
{
    public class TarifaVM
    {


        public Tarifa oTarifas { get; set; }

        public List<SelectListItem> oListaMonedas { get; set; }
    }
}
