namespace Telomando.Models
{
    public class UsuarioRegistro
    {
        public string emailPrincipal {  get; set; }
        public string emailSecundario { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono1 { get; set; }
        public string telefono2 { get; set; }
        public string password { get; set; }
        public string passwordConfirmacion { get; set; }
    }
}
