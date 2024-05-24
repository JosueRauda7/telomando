using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Bodega
{
    public int Idbodega { get; set; }

    public int Idtipobodega { get; set; }

    public int Idsucursal { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<BodegaProducto> BodegaProductos { get; set; } = new List<BodegaProducto>();

    public virtual ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();

    public virtual Sucursale oSucursal { get; set; } = null!;

    public virtual TipoBodega oTipoBodega { get; set; } = null!;
}
