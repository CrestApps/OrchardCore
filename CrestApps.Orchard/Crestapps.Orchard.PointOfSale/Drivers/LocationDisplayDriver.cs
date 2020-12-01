using AutoMapper;
using CrestApps.Data.Models;
using CrestApps.Orchard.PointOfSale.WebPresentation.ViewModels.Locations;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace CrestApps.Orchard.PointOfSale.Drivers
{
    public class LocationDisplayDriver : DisplayDriver<Location>
    {
        private readonly IMapper _mapper;

        public LocationDisplayDriver(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override Task<IDisplayResult> DisplayAsync(Location model, BuildDisplayContext context)
        {
            if (context.DisplayType == "Summary")
            {
                return Task.FromResult<IDisplayResult>(Initialize<DisplayLocationSummaryViewModel>((viewModel) => _mapper.Map(model, viewModel))
                           .Location("Content")
                           );
            }

            return Task.FromResult<IDisplayResult>(Initialize<DisplayLocationViewModel>((viewModel) => _mapper.Map(model, viewModel))
                       .Location("Content"));
        }

        public override Task<IDisplayResult> EditAsync(Location model, BuildEditorContext context)
        {
            return Task.FromResult<IDisplayResult>(Initialize<CreateLocationViewModel>((viewModel) => _mapper.Map(model, viewModel))
                        .Location("Content"));
        }

    }
}
