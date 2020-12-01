using System;

namespace CrestApps.Pixulia.RealEstate.WebFoundation
{
    public static class UrlExtensions
    {
        public static string GetUrlForCors(this Uri uri)
        {
            return uri.ToString().TrimEnd('/');
        }
    }
}
