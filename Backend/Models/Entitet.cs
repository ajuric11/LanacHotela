using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public abstract class Entitet
    {
        [Key]
        public int sifra { get; set; }
    } 
}
