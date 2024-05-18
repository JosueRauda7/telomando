using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Entrega
{
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

    public virtual Bodega IdbodegaNavigation { get; set; } = null!;

    public virtual Cliente IdclienteNavigation { get; set; } = null!;

    public virtual Direccione IddireccionNavigation { get; set; } = null!;

    public virtual Tarifa IdtarifaNavigation { get; set; } = null!;

    public virtual TipoPago IdtipopagoNavigation { get; set; } = null!;

    public virtual Transporte IdtransporteNavigation { get; set; } = null!;
}
