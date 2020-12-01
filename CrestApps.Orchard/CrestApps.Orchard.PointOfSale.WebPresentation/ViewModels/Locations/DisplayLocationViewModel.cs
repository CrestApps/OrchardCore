using CrestApps.Data.Models;
using CrestApps.Mappings;

namespace CrestApps.Orchard.PointOfSale.WebPresentation.ViewModels.Locations
{
    public class DisplayLocationViewModel : DisplayLocationSummaryViewModel, IMapFrom<Location>
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressCity { get; set; }

        public string AddressState { get; set; }

        public string AddressZipCode { get; set; }

        public string Phone1 { get; set; }

        public string Phone2 { get; set; }

        public string Phone3 { get; set; }

        public string Fax1 { get; set; }

        public string Fax2 { get; set; }

        public string WebSite { get; set; }

        public bool IsActive { get; set; }

    }
}
