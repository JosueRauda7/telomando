using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Telomando.Models;

public partial class BodegaProducto
{
    public BodegaProducto()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idbodegaproducto { get; set; }
    [Required(ErrorMessage = "Campo obligatorio.")]

    public int Idbodega { get; set; }
    [Required(ErrorMessage = "Campo obligatorio.")]

    public int Idproducto { get; set; }
    [Required(ErrorMessage = "Campo obligatorio.")]

    public int Stock { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual Bodega oBodega { get; set; } = null!;

    public virtual Producto oProducto { get; set; } = null!;
}
