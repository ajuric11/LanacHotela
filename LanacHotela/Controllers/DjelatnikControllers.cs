using EdunovaAPP.Data;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace EdunovaAPP.Controllers
{
    [ApiController]
    [Route(&quot;api / v1 / [controller] & quot;)]
    public class DjelatnikController : ControllerBase
    {
        // Dependency injection
        // Definiraš privatno svojstvo
        private readonly EdunovaContext _context;

        // Dependency injection
        // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
        public DjelatnikController(EdunovaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return new JsonResult(_context.Djelatnici.ToList());

        }

        [HttpPost]

        public IActionResult Post(Djelatnik djelatnik)
        {
            _context.Djelatnici.Add(djelatnik);
            _context.SaveChanges();
            return new JsonResult(djelatnik);
        }

        [HttpPut]
        [Route(&quot;{sifra: int}&quot;)]
public IActionResult Put(int sifra, Djelatnik djelatnik)
    {
        var smjerIzBaze = _context.Djelatnici.Find(sifra);
        // za sada ručno, kasnije će doći Mapper
        djelatnikIzBaze.Ime = djelatnik.Ime;
        djelatnikIzBaze.Prezime = smjer.Prezime;

        _context.Djelatnici.Update(djelatnikIzBaze);
        _context.SaveChanges();

        return new JsonResult(djelatnikIzBaze);
    }

    [HttpDelete]
    [Route(&quot;{sifra: int}
&quot;)]
[Produces(&quot;application / json & quot;)]
public IActionResult Delete(int sifra)
{
    var djelatnikIzBaze = _context.Djelatnici.Find(sifra);
    _context.Djelatnici.Remove(djelatnikIzBaze);
    _context.SaveChanges();
    return new JsonResult(new { poruka = &quot; Obrisano & quot;
});

}

}
}