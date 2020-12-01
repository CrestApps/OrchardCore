using CrestApps.Data.Models;
using CrestApps.Mappings;
using System;

namespace CrestApps.Orchard.PointOfSale.WebPresentation.ViewModels.Locations
{
    public class DisplayLocationSummaryViewModel : IMapFrom<Location>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
