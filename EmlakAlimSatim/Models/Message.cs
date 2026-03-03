using System.ComponentModel.DataAnnotations;

namespace EmlakAlimSatim.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        [Required]
        public int PropertyId { get; set; }


        public Property? Property { get; set; }

        public DateTime SendDate { get; set; } = DateTime.Now;
    }
}
