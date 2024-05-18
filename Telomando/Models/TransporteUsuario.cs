using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class TransporteUsuario
{
    public int Idtransporteusuario { get; set; }

    public int Idtransporte { get; set; }

    public int Idusuario { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual Transporte IdtransporteNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
