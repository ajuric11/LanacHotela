using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Djelatnik:Entitet
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        
        public int? Hotel { get; set; }
        




    }
}
