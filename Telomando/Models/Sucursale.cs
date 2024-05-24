using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Sucursale
{
    public Sucursale()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idsucursal { get; set; }

    public string Nombre { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Bodega> Bodegas { get; set; } = new List<Bodega>();

    public virtual ICollection<Direccione> Direcciones { get; set; } = new List<Direccione>();

    public virtual ICollection<SucursalPersonal> SucursalPersonals { get; set; } = new List<SucursalPersonal>();

    public virtual ICollection<TransporteSucursal> TransporteSucursals { get; set; } = new List<TransporteSucursal>();
}
