using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CrestApps.Core.Support
{
    public static class ObjectExtensions
    {
        public static StringContent AsJson(this object obj)
        {
            var data = JsonHelper.SerializeToJavascript(obj, false, 100, Formatting.None);
            //JsonConvert.SerializeObject(obj);

            return new StringContent(data, Encoding.UTF8, "application/json");
        }
    }
}
