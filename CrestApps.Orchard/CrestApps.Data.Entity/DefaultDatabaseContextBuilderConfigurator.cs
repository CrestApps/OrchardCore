using Microsoft.EntityFrameworkCore;
using OrchardCore.Data;
using System;
using System.Data.Common;

namespace CrestApps.Data.Entity
{
    public class DefaultDatabaseContextBuilderConfigurator : IDatabaseContextBuilderConfigurator
    {
        private readonly IDbConnectionAccessor Accessor;

        public DefaultDatabaseContextBuilderConfigurator(IDbConnectionAccessor accessor)
        {
            Accessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
        }

        public void Configure(DbContextOptionsBuilder builder, string providerName)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (providerName == null)
            {
                throw new ArgumentNullException(nameof(providerName));
            }

            DbConnection connection = Accessor.CreateConnection();

            switch (providerName.ToLower())
            {
                case "mysql":
                    builder.UseMySql(connection, new MySqlServerVersion(connection.ServerVersion));
                    break;
                case "sqlserver":
                    builder.UseSqlServer(connection);
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"The given provider is not supported.");
            }


            /*
            if (Config.Provider == DatabaseProvider.SqlServer)
            {
                ConfigureSqlServer(builder);
            }
            else if (Config.Provider == DatabaseProvider.MySQL)
            {
                ConfigureMySqlServer(builder);
            }
            else if (Config.Provider == DatabaseProvider.MariaDb)
            {
                ConfigureMariaDbServer(builder);
            }
            else
            {
                throw new ArgumentOutOfRangeException($"The given provider is not supported.");
            }
            */

        }

        protected void ConfigureMySqlServer(DbContextOptionsBuilder builder)
        {
            //ValidateForMySql();
            /*
            var connection = Accessor.CreateConnection();

            builder.UseMySql(connection, new MySqlServerVersion(connection.ServerVersion));
            */
        }

        /*
        protected void ConfigureSqlServer(DbContextOptionsBuilder builder)
        {
            if (string.IsNullOrWhiteSpace(Config.ConnectionString))
            {
                throw new ConfigurationErrorsException($"{nameof(Config.ConnectionString)} is require when using configuring SqlServer.");
            }

            builder.UseSqlServer(Config.ConnectionString);
        }

        protected void ConfigureMySqlServer(DbContextOptionsBuilder builder)
        {
            ValidateForMySql();

            builder.UseMySql(Config.ConnectionString, new MySqlServerVersion(Config.Version));
        }

        protected void ConfigureMariaDbServer(DbContextOptionsBuilder builder)
        {
            ValidateForMySql();

            builder.UseMySql(Config.ConnectionString, new MariaDbServerVersion(Config.Version));
        }
        
        private void ValidateForMySql()
        {
            if (string.IsNullOrWhiteSpace(Config.ConnectionString))
            {
                throw new ConfigurationErrorsException($"{nameof(Config.ConnectionString)} is require when using configuring MySQL server.");
            }

            if (string.IsNullOrWhiteSpace(Config.Version))
            {
                throw new ConfigurationErrorsException($"{nameof(Config.Version)} is require when using configuring MySQL server.");
            }
        }
        */
    }
}
