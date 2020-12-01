using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CrestApps.Pixulia.RealEstate.Data.Entity
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationBuilder AddAppConfiguration(this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> optionsAction)
        {
            return builder.Add(new AppConfigurationSource(optionsAction));
        }
    }
}
