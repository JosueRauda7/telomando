using System;
using System.Collections.Generic;

namespace Telomando.Models;

public partial class Usuario
{
    public Usuario()
    {
        FechaRegistro = DateOnly.FromDateTime(DateTime.Now); // Inicializa con la fecha actual

    }
    public int Idusuario { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int Idtipousuario { get; set; }

    public string? Logueado { get; set; }

    public string Bloqueado { get; set; } = null!;

    public int IntentosLogin { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public bool Activo { get; set; }

    public bool Eliminado { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual ICollection<Direccione> Direcciones { get; set; } = new List<Direccione>();

    public virtual ICollection<Email> Emails { get; set; } = new List<Email>();

    public virtual TipoUsuario IdtipousuarioNavigation { get; set; } = null!;

    public virtual ICollection<SucursalPersonal> SucursalPersonals { get; set; } = new List<SucursalPersonal>();

    public virtual ICollection<TransporteUsuario> TransporteUsuarios { get; set; } = new List<TransporteUsuario>();

    public virtual ICollection<UsuarioPassword> UsuarioPasswords { get; set; } = new List<UsuarioPassword>();
}
