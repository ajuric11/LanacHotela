using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DjelatnikController:ControllerBase
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
        public IActionResult Post(Djelatnik smjer)
        {
            _context.Djelatnici.Add(smjer);
            _context.SaveChanges();
            return new JsonResult(smjer);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Djelatnik smjer)
        {
            var smjerIzBaze = _context.Djelatnici.Find(sifra);
            // za sada ručno, kasnije će doći Mapper
            smjerIzBaze.Ime = smjer.Ime;
            smjerIzBaze.Prezime= smjer.Prezime;
            smjerIzBaze.Hotel = smjer.Hotel;

            _context.Djelatnici.Update(smjerIzBaze);
            _context.SaveChanges();

            return new JsonResult(smjerIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var smjerIzBaze = _context.Djelatnici.Find(sifra);
            _context.Djelatnici.Remove(smjerIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka="Obrisano"});
        }

    }
}
