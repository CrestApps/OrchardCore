using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Data;
using YesSql;

namespace CrestApps.Data.Entity
{
    public static class DependencyInjectionExtensions
    {
        public static void AddEntityDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>((serviceProvider, options) =>
            {
                IDbConnectionAccessor accessor = serviceProvider.GetRequiredService<IDbConnectionAccessor>();
                IStore store = serviceProvider.GetRequiredService<IStore>();

                var configurator = new DefaultDatabaseContextBuilderConfigurator(accessor);
                configurator.Configure(options, store.Dialect.Name);
            });
        }
    }
}
