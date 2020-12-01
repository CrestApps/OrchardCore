using CrestApps.Core.Data.Abstraction;
using CrestApps.Core.Store;
using CrestApps.Pixulia.RealEstate.Data.Models;

namespace CrestApps.Pixulia.RealEstate.Service.Implementations
{
    public class PropertyStore : DataStore<Property>, IPropertyStore
    {
        public PropertyStore(IRepository<Property> repository)
            : base(repository)
        {
        }
    }
}
