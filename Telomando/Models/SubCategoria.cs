using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class SubCategoria
{
    public SubCategoria()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idsubcategoria { get; set; }

    public int Idcategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual Categoria IdcategoriaNavigation { get; set; } = null!;
}
