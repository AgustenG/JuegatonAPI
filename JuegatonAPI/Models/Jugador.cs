using System.ComponentModel.DataAnnotations;

namespace JuegatonAPI.Models
{
    public class Jugador
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        [Key]
        public  string Nickname { get; set; }
        public string? Password { get; set; }
        public string Pais { get; set; }
        public string Color { get; set; }
    }
}
