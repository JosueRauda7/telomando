using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Producto
{
    public Producto()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idproducto { get; set; }

    public string Nombre { get; set; } = null!;

    public int Idmarca { get; set; }

    public decimal Precio { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<BodegaProducto> BodegaProductos { get; set; } = new List<BodegaProducto>();

    public virtual Marca oMarca { get; set; } = null!;

    public virtual ICollection<ProductosDetalle> ProductosDetalles { get; set; } = new List<ProductosDetalle>();
}
