﻿using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Categoria
{
    public int Idcategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<SubCategoria> SubCategoria { get; set; } = new List<SubCategoria>();
}
