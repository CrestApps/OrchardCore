using CrestApps.Common.Helpers;
using CrestApps.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace CrestApps.Data.Entity
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }


        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                string tableName = Str.TrimStart(entityType.GetTableName(), "AspNet").ToSnakeCase();

                entityType.SetTableName(tableName);

                SetPropertyConventions(modelBuilder, entityType);
            };
        }

        protected void SetPropertyConventions(ModelBuilder modelBuilder, IMutableEntityType entityType)
        {
            foreach (IMutableProperty property in entityType.GetProperties())
            {
                if (property.PropertyInfo == null)
                {
                    continue;
                }

                Type propertyType = property.PropertyInfo.PropertyType;

                var prop = modelBuilder.Entity(entityType.ClrType)
                            .Property(propertyType, property.Name);

                if (propertyType.IsTrueEnum())
                {
                    // At this point we know that the property is an enum.
                    // Add the EnumToStringConverter converter to the property so that
                    // the value is stored in the database as a string instead of number 

                    prop.HasConversion<string>();
                }
            }
        }

    }
}
