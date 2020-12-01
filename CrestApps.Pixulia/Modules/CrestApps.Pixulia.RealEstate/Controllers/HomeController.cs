using CrestApps.Pixulia.RealEstate.Data.Entity;
using CrestApps.Pixulia.RealEstate.Data.Models;
using CrestApps.Pixulia.RealEstate.Service;
using CrestApps.Pixulia.RealEstate.Shapes;
using Microsoft.AspNetCore.Mvc;
using OrchardCore;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.ModelBinding;
using System.Threading.Tasks;

namespace CrestApps.Pixulia.RealEstate.Controllers
{
    public class HomeController : Controller, IUpdateModel
    {
        private readonly IPropertyStore _store;
        private readonly IDisplayManager<CardShape> _displayManager;
        private readonly IOrchardHelper _orchardHelper;

        public HomeController(IPropertyStore store, IDisplayManager<CardShape> displayManager, IOrchardHelper orchardHelper)
        {
            _store = store;
            _displayManager = displayManager;
            _orchardHelper = orchardHelper;
        }
        public async Task<IActionResult> Index()
        {
            Property property = await _store.Where(x => x.IsFeatured).AsFirstOrDefaultAsync();

            var viewModel = new CardShape()
            {
                Header = property.FormattedAddress,
                Body = property.Summary,
                Footer = property.Price?.ToString(),
            };

            var shape = await _displayManager.BuildDisplayAsync(viewModel, this);

            return View(shape);
        }

        public async Task<IActionResult> Test()
        {
            Property property = await _store.Where(x => x.IsFeatured).AsFirstOrDefaultAsync();

            var viewModel = new CardShape()
            {
                Header = property.FormattedAddress,
                Body = property.Summary,
                Footer = property.Price?.ToString(),
            };

            // you'll get exceptions if any of these Fields are null
            // the null-conditional operator (?) should be used for any fields which aren't required
            return new ObjectResult(viewModel);
        }
    }
}