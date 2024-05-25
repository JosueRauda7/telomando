﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Telomando.Models;

public partial class Bodega
{
    public Bodega()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idbodega { get; set; }

    [Required(ErrorMessage = "Campo obligatorio.")]
    public int Idtipobodega { get; set; }
    [Required(ErrorMessage = "Campo obligatorio.")]
    public int Idsucursal { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<BodegaProducto> BodegaProductos { get; set; } = new List<BodegaProducto>();

    public virtual ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();

    public virtual Sucursale oSucursal { get; set; } = null!;

    public virtual TipoBodega oTipoBodega { get; set; } = null!;
}
