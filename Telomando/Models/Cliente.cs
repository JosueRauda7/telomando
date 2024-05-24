using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Cliente
{
    public Cliente()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }

    public int Idcliente { get; set; }

    public int Idusuario { get; set; }

    public int Idtipocliente { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Entrega> Entregas { get; set; } = new List<Entrega>();

    public virtual TipoCliente oTipoCliente { get; set; } = null!;

    public virtual Usuario oUsuario { get; set; } = null!;



}
