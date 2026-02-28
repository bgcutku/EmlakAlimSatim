using EmlakAlimSatim.Models;
using Microsoft.EntityFrameworkCore;

namespace EmlakAlimSatim.Data
{
    public class EmlakDbContext: DbContext
    {
        public EmlakDbContext(DbContextOptions<EmlakDbContext>options):base(options)
        { }
        public DbSet<Kullanicilar> kullanicilars { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }



    }
}
