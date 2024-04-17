

using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class EdunovaContext:DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> options) 
            : base(options) { 

        }

        public DbSet<Soba> Sobe { get; set; }
        public DbSet<Djelatnik> Djelatnici { get; set; }
        public DbSet<Gost> Gosti { get; set; }

        public DbSet<Hotel> Hoteli { get; set; }
    }
}
