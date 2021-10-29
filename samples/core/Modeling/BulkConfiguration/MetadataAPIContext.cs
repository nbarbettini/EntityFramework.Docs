using System;
using Microsoft.EntityFrameworkCore;

namespace EFModeling.BulkConfiguration
{
    public class MetadataAPIContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region MetadataAPI
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var propertyInfo in entityType.ClrType.GetProperties())
                {
                    if (propertyInfo.PropertyType == typeof(Money))
                    {
                        entityType.AddProperty(propertyInfo)
                            .SetValueConverter(typeof(Money.MoneyConverter));
                    }
                }
            }
            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=EFModeling.BulkConfiguration;Trusted_Connection=True")
                .LogTo(Console.WriteLine, minimumLevel: Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
    }
}
