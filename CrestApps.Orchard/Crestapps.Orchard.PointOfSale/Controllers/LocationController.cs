using AutoMapper;
using CrestApps.Data.Abstraction;
using CrestApps.Data.Models;
using CrestApps.Orchard.PointOfSale.Permissions;
using CrestApps.Orchard.PointOfSale.WebPresentation.Factories;
using CrestApps.Orchard.PointOfSale.WebPresentation.ViewModels;
using CrestApps.Orchard.PointOfSale.WebPresentation.ViewModels.Locations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Routing;
using OrchardCore.Admin;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.Navigation;
using OrchardCore.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace CrestApps.Orchard.PointOfSale.Controllers
{
    [Admin]
    public class LocationsController : Controller, IUpdateModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDisplayManager<Location> _displayManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly INotifier _notifier;
        private readonly IHtmlLocalizer<LocationsController> _h;
        private readonly IMapper _mapper;
        private readonly ILocationShapeFactory _locationShapeFactory;
        private readonly ISiteService _siteService;
        private const int _defaultPageSize = 25;
        private readonly dynamic _new;

        public LocationsController(IUnitOfWork unitOfWork,
            IDisplayManager<Location> displayManager,
            IAuthorizationService authorizationService,
            INotifier notifier,
            IHtmlLocalizer<LocationsController> htmlLocalizer,
            IMapper mapper,
            ILocationShapeFactory locationShapeFactory,
            ISiteService siteService,
            IShapeFactory shapeFactory)
        {
            _unitOfWork = unitOfWork;
            _displayManager = displayManager;
            _authorizationService = authorizationService;
            _notifier = notifier;
            _h = htmlLocalizer;
            _mapper = mapper;
            _locationShapeFactory = locationShapeFactory;
            _siteService = siteService;
            _new = shapeFactory;
        }

        public async Task<IActionResult> Index(PagerParameters pagerParameters)
        {
            if (!await _authorizationService.AuthorizeAsync(User, LocationPermission.ListLocations))
            {
                return Unauthorized();
            }

            ISite siteSettings = await _siteService.GetSiteSettingsAsync();

            IPagedList<Location> locations = await _unitOfWork.Locations.Query().ToPagedListAsync(pagerParameters.Page ?? 1, pagerParameters.PageSize ?? siteSettings.MaxPageSize);

            var pager = new Pager(pagerParameters, siteSettings.PageSize);

            var routeData = new RouteData();
            var pagerShape = (await _new.Pager(pager)).TotalItemCount(locations.TotalItemCount).RouteData(routeData);


            var items = new List<dynamic>();
            foreach (var location in locations)
            {
                items.Add(await _displayManager.BuildDisplayAsync(location, this, "Summary"));
            }

            var viewModel = new ListContentsViewModel()
            {
                Pager = pagerShape,
                ContentItems = items,
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            if (!await _authorizationService.AuthorizeAsync(User, LocationPermission.CreateLocation))
            {
                return Unauthorized();
            }

            IShape shape = await _displayManager.BuildEditorAsync(new Location(), this, true);

            return View(shape);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(Prefix = nameof(Location))] Location viewModel)
        {
            if (!await _authorizationService.AuthorizeAsync(User, LocationPermission.CreateLocation))
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {
                Location location = _mapper.Map<Location>(viewModel);

                _unitOfWork.Locations.Add(location);
                await _unitOfWork.Locations.SaveAsync();

                _notifier.Success(_h["New location was created."]);

                return RedirectToAction(nameof(Index));
            }

            IShape shape = await _displayManager.BuildEditorAsync(viewModel, this, true);

            return View(shape);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (!await _authorizationService.AuthorizeAsync(User, LocationPermission.EditLocation))
            {
                return Unauthorized();
            }

            Location location = await _unitOfWork.Locations.GetAsync(id);

            if (location == null)
            {
                _notifier.Error(_h["Unable to find the requested location."]);

                return RedirectToAction(nameof(Index));
            }

            IShape shape = await _displayManager.BuildEditorAsync(location, this, false);

            return View(shape);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind(Prefix = nameof(Location))] Location viewModel)
        {
            if (!await _authorizationService.AuthorizeAsync(User, LocationPermission.EditLocation))
            {
                return Unauthorized();
            }

            Location location = await _unitOfWork.Locations.GetAsync(id);

            if (location == null)
            {
                _notifier.Error(_h["Unable to find the requested location."]);

                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                _mapper.Map(viewModel, location);

                _unitOfWork.Locations.Update(location);
                await _unitOfWork.SaveAsync();
                _notifier.Success(_h["Location information was successfully updated."]);

                return RedirectToAction(nameof(Index));
            }

            IShape shape = await _displayManager.BuildEditorAsync(location, this, false);

            return View(shape);
        }


        public async Task<IActionResult> Display(Guid id)
        {
            if (!await _authorizationService.AuthorizeAsync(User, LocationPermission.DisplayLocation))
            {
                return Unauthorized();
            }

            Location location = await _unitOfWork.Locations.GetAsync(id);

            if (location == null)
            {
                _notifier.Error(_h["Unable to find the requested location."]);

                return RedirectToAction(nameof(Index));
            }

            IShape shape = await _displayManager.BuildDisplayAsync(location, this);

            return View(shape);
        }
    }
}
