﻿using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Email
{
    public int Idemail { get; set; }

    public int Idusuario { get; set; }

    public string Email1 { get; set; } = null!;

    public string Email2 { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
