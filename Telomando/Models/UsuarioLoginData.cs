namespace Telomando.Models
{
    public class UsuarioLoginData
    {
        public int idUsuario {  get; set; }
        public string username { get; set; }
        public bool logueado { get; set; }
        public string correo { get; set; }
        public int idTipoUsuario { get; set; }
    }
}
