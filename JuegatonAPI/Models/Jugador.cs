using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.Serialization;

namespace JuegatonAPI.Models
{
    public class Jugador
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        [Key]
        public  string Nickname { get; set; }
        [IgnoreDataMember]
        public string? Password { get; set; }
        public string Pais { get; set; }
        public string Color { get; set; }

        public int Puntuacion { get; set; }
        public int Posicion { get; set; }

    }
}
