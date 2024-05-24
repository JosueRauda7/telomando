using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Ciudade
{

    public Ciudade()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idciudad { get; set; }

    public int Idmunicipio { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Direccione> Direcciones { get; set; } = new List<Direccione>();

    public virtual Municipio oMunicipios { get; set; } = null!;
}
