using EdunovaAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace EdunovaAPP.Data
{
    public class EdunovaContext : DbContext
    {
        public EdunovaContext(DbContextOptions&lt; EdunovaContext&gt; options)
: base(options) {

}

    public DbSet&lt;Djelatnik&gt; Djelatnici { get; set; }

}
}
