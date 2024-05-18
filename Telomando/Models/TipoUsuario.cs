using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class TipoUsuario
{
    public int Idtipousuario { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
