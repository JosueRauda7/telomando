using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class EstadoEntrega
{

    public EstadoEntrega()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idestadoentrega { get; set; }

    public int Idtipoestadoentrega { get; set; }

    public string? InformacionAdicional { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual TipoEstadoEntrega IdtipoestadoentregaNavigation { get; set; } = null!;
}
