using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Departamento
{
    public int Iddepartamento { get; set; }

    public int Idpaises { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual Paise oPaises { get; set; } = null!;

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
