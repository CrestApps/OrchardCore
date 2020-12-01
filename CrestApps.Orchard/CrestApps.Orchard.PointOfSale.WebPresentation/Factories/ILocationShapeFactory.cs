using CrestApps.Data.Models;
using CrestApps.Orchard.PointOfSale.WebPresentation.ViewModels.Locations;
using OrchardCore.DisplayManagement;
using System.Threading.Tasks;
using X.PagedList;

namespace CrestApps.Orchard.PointOfSale.WebPresentation.Factories
{
    public interface ILocationShapeFactory
    {
        Task<IShape> GetForCreateAsync(CreateLocationViewModel viewModel = null);
        Task<IShape> GetForEditAsync(Location location);
        Task<IShape> GetForDisplayAsync(Location location);
        Task<IShape> GetForIndexAsync(IPagedList<DisplayLocationViewModel> locations);
    }
}
