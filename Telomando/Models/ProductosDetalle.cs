using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class ProductosDetalle
{
    public int Idproductosdetalles { get; set; }

    public int Idproducto { get; set; }

    public string Atributo { get; set; } = null!;

    public string Valor { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual Producto IdproductoNavigation { get; set; } = null!;
}
