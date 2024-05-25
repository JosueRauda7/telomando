using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telomando.Models;

public partial class Transporte
{
    public Transporte()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idtransporte { get; set; }

    public int Idmarcatransporte { get; set; }

    public int Idtipotransporte { get; set; }

    public string Placa { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();

    public virtual ICollection<TransporteSucursal> TransporteSucursals { get; set; } = new List<TransporteSucursal>();

    public virtual ICollection<TransporteUsuario> TransporteUsuarios { get; set; } = new List<TransporteUsuario>();
    [NotMapped]
    public virtual MarcaTransporte MarcaTransporte { get; set; } = null!;
    [NotMapped]
    public virtual TipoTransporte TipoTransporte { get; set; } = null!;
}
