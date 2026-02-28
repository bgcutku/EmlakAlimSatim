using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmlakAlimSatim.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık zorunludur.")]
        [StringLength(200)]
        [Display(Name = "Başlık")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Display(Name = "Fiyat (₺)")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(Name = "Metrekare")]
        public int SquareMeters { get; set; }

        [Display(Name = "Oda Sayısı")]
        public string? RoomCount { get; set; } // "1+1", "2+1" etc.

        [Display(Name = "Bina Yaşı")]
        public int? BuildingAge { get; set; }

        [Display(Name = "Kat")]
        public int? Floor { get; set; }

        [Display(Name = "Toplam Kat")]
        public int? TotalFloors { get; set; }

        [Display(Name = "Isıtma Tipi")]
        public string? HeatingType { get; set; }

        [Display(Name = "İlan Tipi")]
        public string ListingType { get; set; } = "Satılık";

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        [Display(Name = "Kapak Fotoğrafı")]
        public string? CoverImage { get; set; }

        // Foreign Keys

        [Required]
        [Display(Name = "İlan Sahibi")]
        public int KullaniciId { get; set; }

        [Required]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Şehir")]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "İlçe")]
        public int DistrictId { get; set; }

        [Display(Name = "Adres")]
        public string? Address { get; set; }

        // Navigation
        public Kullanicilar? Kullanici { get; set; }
        public Category? Category { get; set; }
        public City? City { get; set; }
        public District? District { get; set; }
        public ICollection<PropertyImage> Images { get; set; } = new List<PropertyImage>();
    }
}
