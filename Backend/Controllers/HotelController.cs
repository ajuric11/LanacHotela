using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HotelController : ControllerBase
    {
        // Dependency injection
        // Definiraš privatno svojstvo
        private readonly EdunovaContext _context;

        // Dependency injection
        // U konstruktoru primir instancu i dodjeliš privatnom svojstvu
        public HotelController(EdunovaContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {

            return new JsonResult(_context.Hoteli.Find(sifra));


        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_context.Hoteli.ToList());
        }


        [HttpPost]
        public IActionResult Post(Hotel hotel)
        {
            _context.Hoteli.Add(hotel);
            _context.SaveChanges();
            return new JsonResult(hotel);
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, Hotel hotel)
        {
            var hotelIzBaze = _context.Hoteli.Find(sifra);
            // za sada ručno, kasnije će doći Mapper
            hotelIzBaze.Naziv = hotel.Naziv;
            hotelIzBaze.Mjesto = hotel.Mjesto;


            _context.Hoteli.Update(hotelIzBaze);
            _context.SaveChanges();

            return new JsonResult(hotelIzBaze);
        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            var hotelIzBaze = _context.Hoteli.Find(sifra);
            _context.Hoteli.Remove(hotelIzBaze);
            _context.SaveChanges();
            return new JsonResult(new { poruka = "Obrisano" });
        }

    }
}
