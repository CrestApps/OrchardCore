using CrestApps.Core.Support;
using CrestApps.Pixulia.RealEstate.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CrestApps.Pixulia.RealEstate.Data.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public static string GetTableName(string name)
        {
            return Str.StudlyToSnake(Str.TrimStart(name, "AspNet").Replace("RealEstate", "Realestate"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(GetTableName(entityType.GetTableName()));

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

                if (property.IsPrimaryKey() && IsPrimary(property.PropertyInfo))
                {

                    // At this point we know that the property is a primary key
                    modelBuilder.Entity(entityType.ClrType)
                                .Property(property.Name)
                                .ValueGeneratedOnAdd();
                }

                else if (property.PropertyInfo.PropertyType.IsTrueEnum())
                {
                    // At this point we know that the property is an enum.
                    // Add the EnumToStringConverter converter to the property so that
                    // the value is stored in the database as a string instead of number 

                    modelBuilder.Entity(entityType.ClrType)
                                .Property(property.Name)
                                .HasConversion<string>();
                }
            }
        }

        protected bool IsPrimary(PropertyInfo property)
        {
            var identityTypes = new List<Type> {
                    typeof(short),
                    typeof(int),
                    typeof(long)
                };

            return property.Name.Equals("Id", StringComparison.OrdinalIgnoreCase) && identityTypes.Contains(property.PropertyType);
        }
    }
}
