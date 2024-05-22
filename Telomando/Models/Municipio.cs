using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Municipio
{
    public int Idmunicipio { get; set; }

    public int? Iddepartamento { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Ciudade> Ciudades { get; set; } = new List<Ciudade>();

    public virtual Departamento? oDepartamentos { get; set; }
}
