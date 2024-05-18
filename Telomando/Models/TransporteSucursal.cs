using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class TransporteSucursal
{
    public int Idtransporteusuario { get; set; }

    public int Idtransporte { get; set; }

    public int Idsucursal { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual Sucursale IdsucursalNavigation { get; set; } = null!;

    public virtual Transporte IdtransporteNavigation { get; set; } = null!;
}
