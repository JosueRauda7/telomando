﻿using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Moneda
{
    public int Idmoneda { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Tarifa> Tarifas { get; set; } = new List<Tarifa>();
}
