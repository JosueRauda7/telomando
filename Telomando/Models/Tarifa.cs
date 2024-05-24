using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Telomando.Models;

public partial class Tarifa
{
    public Tarifa()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idtarifa { get; set; }

    [Required(ErrorMessage = "Campo requerido.")]
    public int Idmoneda { get; set; }
    [Required(ErrorMessage = "Campo requerido.")]

    public decimal Valor { get; set; }
    [Required(ErrorMessage = "Campo requerido.")]

    public decimal? PorcentajeExtra { get; set; }
    [Required(ErrorMessage = "Campo requerido.")]

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();


    public virtual Moneda oMomedas { get; set; } = null!;
}
