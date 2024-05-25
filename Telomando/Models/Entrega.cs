using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Entrega
{
    
    public Entrega()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Identrega { get; set; }

    public string Codigo { get; set; } = null!;

    public int Idcliente { get; set; }

    public int Iddireccion { get; set; }

    public string? InformacionAdicional { get; set; }

    public int Idtipopago { get; set; }

    public int Idtransporte { get; set; }

    public int Idtarifa { get; set; }

    public int Idbodega { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual Bodega oBodega { get; set; } = null!;

    public virtual Cliente oCliente { get; set; } = null!;

    public virtual Direccione oDireccion { get; set; } = null!;

    public virtual Tarifa oTarifa { get; set; } = null!;

    public virtual TipoPago oTipoPago { get; set; } = null!;

    public virtual Transporte oTrasnporte { get; set; } = null!;
}
