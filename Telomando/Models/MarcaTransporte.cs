using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class MarcaTransporte
{
    public int Idmarcatransporte { get; set; }

    public int Idmodelotransporte { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ModeloTransporte IdmodelotransporteNavigation { get; set; } = null!;
}
