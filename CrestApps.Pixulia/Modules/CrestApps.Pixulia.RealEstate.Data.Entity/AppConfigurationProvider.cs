using CrestApps.Pixulia.RealEstate.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CrestApps.Pixulia.RealEstate.Data.Entity
{
    internal class AppConfigurationProvider : ConfigurationProvider
    {
        private Action<DbContextOptionsBuilder> OptionsAction;

        public AppConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            OptionsAction(builder);

            using (var dbContext = new ApplicationDbContext(builder.Options))
            {
                Dictionary<string, string> data = new Dictionary<string, string>();

                Setting settings = dbContext.Settings.FirstOrDefault();

                if (settings != null)
                {
                    foreach (PropertyInfo property in settings.GetType().GetProperties())
                    {
                        object value = property.GetValue(settings);

                        if (property.Name.StartsWith("Global"))
                        {

                        }

                        Data.TryAdd($"AppSettings:{property.Name}", (value?.ToString()) ?? string.Empty);
                    }
                }
                /*
                List<AuthenticationProvider> providers = dbContext.AuthenticationProviders.Where(x => x.IsActive).ToList();
                int totalProvider = providers.Count();
                if (totalProvider > 0)
                {
                    for (int i = 0; i < totalProvider; i++)
                    {
                        Data.TryAdd($"Providers:{i}:AppId", providers[i].AppId);
                        Data.TryAdd($"Providers:{i}:Secret", providers[i].Secret);
                        Data.TryAdd($"Providers:{i}:Name", providers[i].Name.ToString());
                    }
                }
                */
            }
        }
    }
}
