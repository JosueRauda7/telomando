using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class SucursalPersonal
{
    public int Idsucursalpersonal { get; set; }

    public int Idsucursal { get; set; }

    public int Idusuario { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual Sucursale IdsucursalNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
