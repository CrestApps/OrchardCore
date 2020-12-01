using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace CrestApps.Pixulia.RealEstate
{
    public class Migrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            //_contentDefinitionManager.MigrateFieldSettings<FeaturedPropertyField, FeaturedPropertyFieldSetting>();

            //_contentDefinitionManager.AlterPartDefinition(nameof(FeaturedPropertyPart), (part) =>
            //{
            //    part.WithDescription("This part if for the featured properties");
            //});

            // This code will be run when the feature is enabled
            _contentDefinitionManager.AlterTypeDefinition("Featured_Properties", (type) =>
            {
                type.Stereotype("Widget");

                //.WithPart(nameof(FeaturedPropertyPart), (part) =>
                //{
                //    part.WithDescription("This part if for the featured properties")
                //    .WithPosition("1");
                //});
                //type.WithSettings("Max_Property");
            });

            return 1;
        }
    }
}
