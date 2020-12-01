using AutoMapper;
using CrestApps.Data.Models;
using CrestApps.Orchard.PointOfSale.WebPresentation.ViewModels.Locations;
using OrchardCore.DisplayManagement;
using System.Threading.Tasks;
using X.PagedList;

namespace CrestApps.Orchard.PointOfSale.WebPresentation.Factories.Implementations
{
    public class LocationShapeFactory : ILocationShapeFactory
    {
        private readonly IShapeFactory _shapeFactory;
        private readonly IMapper _mapper;

        public LocationShapeFactory(IShapeFactory shapeFactory, IMapper mapper)
        {
            _shapeFactory = shapeFactory;
            _mapper = mapper;
        }

        public async Task<IShape> GetForCreateAsync(CreateLocationViewModel viewModel = null)
        {
            IShape shape = await _shapeFactory.CreateAsync("CreateForm", viewModel ?? new CreateLocationViewModel());

            return shape;
        }

        public async Task<IShape> GetForDisplayAsync(Location location)
        {
            DisplayLocationViewModel viewModel = _mapper.Map<DisplayLocationViewModel>(location);

            IShape shape = await _shapeFactory.CreateAsync(nameof(DisplayLocationViewModel), viewModel);

            return shape;
        }

        public async Task<IShape> GetForEditAsync(Location location)
        {
            EditLocationViewModel viewModel = _mapper.Map<EditLocationViewModel>(location);

            IShape shape = await _shapeFactory.CreateAsync(nameof(EditLocationViewModel), viewModel);

            return shape;
        }

        public async Task<IShape> GetForIndexAsync(IPagedList<DisplayLocationViewModel> locations)
        {
            ListLocatationsViewModel viewModel = new ListLocatationsViewModel()
            {
                Records = locations,
            };

            IShape shape = await _shapeFactory.CreateAsync(nameof(EditLocationViewModel), viewModel);

            return shape;
        }
    }
}
