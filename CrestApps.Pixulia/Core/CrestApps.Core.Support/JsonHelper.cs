using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CrestApps.Core.Support
{
    public static class JsonHelper
    {
        public static string SerializeToJavascript(object obj, bool ignoreVirtualProperties = true, int maxDepth = 1, Formatting formatting = Formatting.Indented)
        {
            IContractResolver resolver = new CamelCasePropertyNamesContractResolver();

            if (!ignoreVirtualProperties)
            {
                resolver = new CamelCasePropertyNamesContractResolver();
            }

            var settings = new JsonSerializerSettings
            {
                ContractResolver = resolver,
                DateFormatString = "g",
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = formatting,
                MaxDepth = maxDepth,
            };

            settings.Converters.Add(new StringEnumConverter
            {
                AllowIntegerValues = false
            });

            return JsonConvert.SerializeObject(obj, settings);
        }


    }
}
