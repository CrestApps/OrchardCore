using CrestApps.Core.Foundation;

namespace CrestApps.Core.WebFoundation
{
    public interface IRegisterPerRequest : IRegisterToContainer
    {
    }

    public interface IRegisterPerRequest<T> : IRegisterPerRequest
    {
    }
}
