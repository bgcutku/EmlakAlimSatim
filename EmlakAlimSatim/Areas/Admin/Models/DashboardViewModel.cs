using EmlakAlimSatim.Models;

namespace EmlakAlimSatim.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int TotalPropertiesCount { get; set; }
        public int SaleCount { get; set; }
        public int RentCount { get; set; }
        public int TotalMessagesCount { get; set; }

        public List<Property> RecentProperties { get; set; }
        public List<Message> RecentMessages { get; set; }

    }
}
