using AutoMapper;

namespace CrestApps.Mappings
{
    public interface IMapFrom<T> : IMap
    {
    }

    public interface IMapFrom : IMap
    {
        void Map(IMapperConfigurationExpression expression);
    }
}
