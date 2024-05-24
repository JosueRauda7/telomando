using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class TipoBodega
{
    public TipoBodega()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idtipobodega { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Bodega> Bodegas { get; set; } = new List<Bodega>();
}
