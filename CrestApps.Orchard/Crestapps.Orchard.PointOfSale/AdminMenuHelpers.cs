using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;
using System;

namespace CrestApps.Orchard.PointOfSale
{
    public static class AdminMenuHelpers
    {
        public static bool IsAdminMenu(string name)
        {
            return string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase);
        }

        public static void AddPointOfSaleMenu(this NavigationBuilder builder, IStringLocalizer T, Action<NavigationItemBuilder> itemBuilder)
        {
            builder.Add(T["Point of Sale"], "0", mainMenu =>
            {
                mainMenu.AddClass("PointOfSale")
                               .Id("PointOfSale")
                               .LinkToFirstChild(true);

                itemBuilder(mainMenu);
            });
        }




        public static NavigationItemBuilder PosAction(this NavigationItemBuilder builder, string actionName, string controllerName)
        {
            return builder.Action(actionName, controllerName, new { area = PosConstants.Namespace });
        }
    }
}
