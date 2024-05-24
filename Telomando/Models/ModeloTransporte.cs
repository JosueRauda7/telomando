using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class ModeloTransporte
{
    public ModeloTransporte()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idmodelotransporte { get; set; }

    public string Nombre { get; set; } = null!;

    public short Anio { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<MarcaTransporte> MarcaTransportes { get; set; } = new List<MarcaTransporte>();
}
