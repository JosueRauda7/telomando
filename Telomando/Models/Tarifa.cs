using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Tarifa
{
    public Tarifa()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idtarifa { get; set; }

    public int Idmoneda { get; set; }

    public decimal Valor { get; set; }

    public decimal? PorcentajeExtra { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();


    public virtual Moneda IdmonedaNavigation { get; set; } = null!;
}
