﻿using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public int Idusuario { get; set; }

    public int Idtipocliente { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();

    public virtual TipoCliente IdtipoclienteNavigation { get; set; } = null!;

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
