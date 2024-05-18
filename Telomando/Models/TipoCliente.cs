using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class TipoCliente
{
    public int Idtipocliente { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
