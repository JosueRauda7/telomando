using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Direccione
{
    public Direccione()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }

    public int Iddireccion { get; set; }

    public int? Idusuario { get; set; }

    public int? Idsucursal { get; set; }

    public int Idciudad { get; set; }

    public string? Direccion1 { get; set; }

    public string? Direccion2 { get; set; }

    public string? Direccion3 { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();

    public virtual Ciudade IdciudadNavigation { get; set; } = null!;

    public virtual Sucursale? IdsucursalNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
