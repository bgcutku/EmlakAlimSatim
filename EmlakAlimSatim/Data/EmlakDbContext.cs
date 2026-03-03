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
        public DbSet<Message> Messages { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<District>()
                .HasOne(d => d.City)
                .WithMany(c => c.Districts)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Properties)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.City)
                .WithMany(c => c.Properties)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.District)
                .WithMany(d => d.Properties)
                .HasForeignKey(p => p.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Kullanicilar>()
                .HasData(new Kullanicilar
                {
                    KullaniciID = 12,
                    KullaniciAdi = "admin",
                    Ad = "Admin",
                    Soyad = "User",
                    Email = "admin@emlakalimsatim.com",
                    PhoneNumber = "1234567890",
                    Role = "Admin",
                    KayitTarihi = DateTime.Now,
                    SifreHash = "Admin1234.!"

                });

            //Seed Kateori
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Konut", Icon = "fa-home", IsActive = true },
                new Category { Id = 2, Name = "Arsa", Icon = "fa-tree", IsActive = true },
                new Category { Id = 3, Name = "İşyeri", Icon = "fa-building", IsActive = true },
                new Category { Id = 4, Name = "Bina", Icon = "fa-city", IsActive = true }
            );

            //Seed Şehirler
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "İstanbul" },
                new City { Id = 2, Name = "Ankara" }
            );

            //Seed İlçeler
            modelBuilder.Entity<District>().HasData(
                new District { Id = 1, Name = "Kadıköy", CityId = 1 },                
                new District { Id = 3, Name = "Çankaya", CityId = 2 }                
            );


        }


    }
}
