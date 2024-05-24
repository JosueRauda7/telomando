using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class BodegaProducto
{
    public int Idbodegaproducto { get; set; }

    public int Idbodega { get; set; }

    public int Idproducto { get; set; }

    public int Stock { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual Bodega oBodega { get; set; } = null!;

    public virtual Producto oProducto { get; set; } = null!;
}
