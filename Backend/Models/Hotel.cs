using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Hotel
    {


        public string? Naziv { get; set; }
        public string? Mjesto { get; set; }

        public int? Gost { get; set; }
        public int? Soba { get; set; }

    }
}
