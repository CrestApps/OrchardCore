using OrchardCore.ResourceManagement;

namespace Crestapps.Orchard.PointOfSale
{
    public class ResourceManifest : IResourceManifestProvider
    {
        private readonly IResourceManager ResourceManager;

        public ResourceManifest(IResourceManager resourceManager)
        {
            ResourceManager = resourceManager;
        }

        public void BuildManifests(IResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest.DefineScript("CollectionModule-Main")
                    .SetUrl("~/Crestapps.Orchard.PointOfSale/js/main.min.js", "~/Crestapps.Orchard.PointOfSale/js/main.js")
                    .SetVersion("1.0.0");


            // Register Resources
            RequireSettings setting = ResourceManager.RegisterResource("script", "Crestapps.Orchard.PointOfSale-Main");
            setting.AtFoot();
        }
    }
}
