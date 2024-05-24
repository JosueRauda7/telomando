using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Telomando.Models;

public partial class Paise
{
    public int Idpaises { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
