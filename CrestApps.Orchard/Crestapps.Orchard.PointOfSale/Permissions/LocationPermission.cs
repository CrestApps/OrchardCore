using OrchardCore.Security.Permissions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrestApps.Orchard.PointOfSale.Permissions
{
    public class LocationPermission : IPermissionProvider
    {
        // Define the permissions (can be multiple) that you want to add to roles on the dashboard (or from here as a
        // default). In a PermissionProvider it's a good idea to define the permission as publicly accessible so you
        // can reference them as you've seen it for checking the EditContent permission before.


        public static readonly Permission ListLocations = new Permission(nameof(ListLocations), "List POS Locations.");

        // Here's another permission that has a third parameter which is called "ImpliedBy". It means that everybody
        // who has the ManagePersons permission also automatically possesses the AccessPersonListDashboard permission
        // as well. Be aware that because of this AccessPersonListDashboard should be written after ManagePersons.
        public static readonly Permission CreateLocation = new Permission(nameof(CreateLocation), "Create POS Location");

        public static readonly Permission EditLocation = new Permission(nameof(EditLocation), "Edit POS Location");

        public static readonly Permission DisplayLocation = new Permission(nameof(DisplayLocation), "Display POS Location");


        public static readonly Permission ManageLocations = new Permission(nameof(ManageLocations), "Manage POS Locations.",
            new[] {
                ListLocations,
                CreateLocation,
                EditLocation,
                DisplayLocation
            });

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() =>
            // Giving some defaults: which roles should possess which permissions.
            new[]
            {
                new PermissionStereotype
                {
                    // Administrators will have all the permissions by default.
                    Name = PosConstants.AdministratorRole,
                    // Since AccessPersonListDashboard is implied by EditPersonList we don't have to list the former here.
                    Permissions = new[] { ListLocations, CreateLocation, EditLocation },
                },
            };

        public Task<IEnumerable<Permission>> GetPermissionsAsync() => Task.FromResult(new[]
            {
                ListLocations,
                CreateLocation,
                EditLocation,
                DisplayLocation,
                ManageLocations,
            }
            .AsEnumerable());
    }
}
