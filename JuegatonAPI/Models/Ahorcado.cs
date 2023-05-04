using System.ComponentModel.DataAnnotations;

namespace JuegatonAPI.Models
{
    public class Ahorcado
    {
        [Key]
        public int Palabra_Id { get; set; }
        
        public string Palabra { get; set; }
    }

}

