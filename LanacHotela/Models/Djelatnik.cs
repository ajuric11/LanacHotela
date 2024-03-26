using System.ComponentModel.DataAnnotations.Schema;

namespace EdunovaAPP.Models
{
    public class Djelatnik : Entitet
    {
        public string? Ime { get; set; }
        public int? Prezime { get; set; }

        [Column(&quot;vaucer & quot;)] // na svojim ZR ovo nužno ne morate
                                       // public bool? Verificiran { get; set; }

    }
}