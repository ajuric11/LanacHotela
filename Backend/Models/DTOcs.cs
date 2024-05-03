using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public record SobaDTORead(int sifra, string Oznaka, string Kapacitet);
    
       
    

    public record SobaDTOInsertUpdate([Required(ErrorMessage = "Oznaka obavezna")] string? Oznaka, string? Kapacitet);
    

}