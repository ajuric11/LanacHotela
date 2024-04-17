using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GostController : ControllerBase
    {
        // Dependency injection
        // Definiraš privatno svojstvo
        private readonly EdunovaContext _context;

        // Dependency injection
        // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
        public GostController(EdunovaContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {

            return new JsonResult(_context.Gosti.Find(sifra));


        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Gosti.ToList());
        }


        [HttpPost]
        public IActionResult Post(Gost gost)
        {
            _context.Gosti.Add(gost);
            _context.SaveChanges();
            return new JsonResult(gost);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Gost gost)
        {
            var gostIzBaze = _context.Gosti.Find(sifra);
            // za sada ručno, kasnije će doći Mapper
            gostIzBaze.Ime = gost.Ime;
            gostIzBaze.Prezime = gost.Prezime;


            _context.Gosti.Update(gostIzBaze);
            _context.SaveChanges();

            return new JsonResult(gostIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var gostIzBaze = _context.Gosti.Find(sifra);
            _context.Gosti.Remove(gostIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka = "Obrisano" });
        }

    }
}
