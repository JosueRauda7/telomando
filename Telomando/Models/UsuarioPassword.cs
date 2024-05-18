using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class UsuarioPassword
{
    public int Idusuariopassword { get; set; }

    public int Idusuario { get; set; }

    public byte[] Pwd { get; set; } = null!;

    public DateOnly FechaCreacion { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
