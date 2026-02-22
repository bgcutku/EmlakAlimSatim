using EmlakAlimSatim.Models;
using Microsoft.EntityFrameworkCore;

namespace EmlakAlimSatim.Data
{
    public class EmlakDbContext: DbContext
    {
        public EmlakDbContext(DbContextOptions<EmlakDbContext>options):base(options)
        { }
        public DbSet<Kullanicilar> kullanicilars { get; set; }


    }
}
