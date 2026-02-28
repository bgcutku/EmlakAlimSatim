namespace EmlakAlimSatim.Models
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public bool IsCover { get; set; }
        public Property? Property { get; set; }
    }
}
