using System.ComponentModel.DataAnnotations;

namespace JuegatonAPI.Models
{
    public class Leaderboard
    {
        public int Posicion { get; set; }
        [Key]
        public string Nickname { get; set; }
        public long Puntuacion { get; set; }
        public string Pais { get; set; }

    }
}
