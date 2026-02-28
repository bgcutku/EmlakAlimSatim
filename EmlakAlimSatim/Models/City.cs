namespace EmlakAlimSatim.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<District>Districts { get; set; } = new List<Districts>();
        public ICollection<Property>Properties { get; set; } = new List<Property>();
    }
}
