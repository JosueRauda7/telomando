﻿using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class TipoEstadoEntrega
{
    public int Idtipoestadoentrega { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<EstadoEntrega> EstadoEntregas { get; set; } = new List<EstadoEntrega>();
}
