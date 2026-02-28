using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmlakAlimSatim.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Kategori Adı Zorunludur.")]
        [StringLength(100, ErrorMessage = "Kategori Adı en fazla 100 karakter olabilir.")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; } = string.Empty;

        [Display(Name ="Simge")]
        public string? Icon { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }

        public ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
