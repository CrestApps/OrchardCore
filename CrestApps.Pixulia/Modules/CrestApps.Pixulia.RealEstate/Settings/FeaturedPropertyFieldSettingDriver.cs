using CrestApps.Pixulia.RealEstate.Fields;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;

namespace CrestApps.Pixulia.RealEstate.Settings
{
    public class FeaturedPropertyFieldSettingDriver : ContentPartFieldDefinitionDisplayDriver<FeaturedPropertyField>
    {
        public override IDisplayResult Edit(ContentPartFieldDefinition partFieldDefinition)
        {
            return Initialize<FeaturedPropertyFieldSetting>($"{nameof(FeaturedPropertyFieldSetting)}_Edit", model => partFieldDefinition.PopulateSettings(model))
                .Location("Content");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition partFieldDefinition, UpdatePartFieldEditorContext context)
        {
            var model = new FeaturedPropertyFieldSetting();

            await context.Updater.TryUpdateModelAsync(model, Prefix);

            context.Builder.WithSettings(model);

            return Edit(partFieldDefinition);
        }
    }
}
