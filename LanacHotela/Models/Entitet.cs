using System.ComponentModel.DataAnnotations;

namespace EdunovaAPP.Models
{
    public abstract class Entitet
    {
        [Key]
        public int Sifra { get; set; }
    }
}