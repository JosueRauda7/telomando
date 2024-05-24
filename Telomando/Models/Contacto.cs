using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Contacto
{

    public Contacto()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idcontacto { get; set; }

    public int Idusuario { get; set; }

    public string Contacto1 { get; set; } = null!;

    public string Contacto2 { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual Usuario IdusuarioNavigation { get; set; } = null!;
}
