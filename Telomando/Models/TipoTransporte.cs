using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class TipoTransporte
{
    public int Idtipotransporte { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }
}
