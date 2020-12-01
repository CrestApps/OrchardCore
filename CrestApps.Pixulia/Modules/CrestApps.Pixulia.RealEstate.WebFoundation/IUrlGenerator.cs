using CrestApps.Pixulia.RealEstate.Data.Models.Enums;

namespace CrestApps.Pixulia.RealEstate.WebFoundation
{
    public interface IUrlGenerator
    {
        string ByRoute(PageKey key, object values, bool fullUrl);
        string ByRoute(PageKey key, bool fullUrl);
        string Cononical(PageKey key);
        string Cononical(PageKey key, object values);
        string BaseUrl();
        string Photo(string path = null);
        string Thumbnail(string path = null);
        string PrimaryThumbnail(int integrationId, long matrixId);
        string Sharable(string path = null);
        string Asset(string path = null, bool addVerion = false);
    }
}
