using X.PagedList;

namespace CrestApps.Orchard.PointOfSale.WebPresentation.ViewModels.Locations
{
    public class ListLocatationsViewModel
    {
        public IPagedList<DisplayLocationViewModel> Records { get; set; }
    }
}
