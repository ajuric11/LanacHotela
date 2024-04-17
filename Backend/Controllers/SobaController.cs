using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SobaController:ControllerBase
    {
        // Dependency injection
        // Definiraš privatno svojstvo
        private readonly EdunovaContext _context;

        // Dependency injection
        // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
        public SobaController(EdunovaContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
        
                return new JsonResult(_context.Sobe.Find(sifra));


        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Sobe.ToList());
        }


        [HttpPost]
        public IActionResult Post(Soba soba)
        {
            _context.Sobe.Add(soba);
            _context.SaveChanges();
            return new JsonResult(soba);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Soba soba)
        {
            var sobaIzBaze = _context.Sobe.Find(sifra);
            // za sada ručno, kasnije će doći Mapper
            sobaIzBaze.Oznaka = soba.Oznaka;
            sobaIzBaze.Kapacitet= soba.Kapacitet;
           

            _context.Sobe.Update(sobaIzBaze);
            _context.SaveChanges();

            return new JsonResult(sobaIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var sobaIzBaze = _context.Sobe.Find(sifra);
            _context.Sobe.Remove(sobaIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka="Obrisano"});
        }

    }
}
