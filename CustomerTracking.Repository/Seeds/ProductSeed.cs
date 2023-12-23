using CustomerTracking.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTracking.Repository.Seeds
{
    internal class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryId = 1, Price = 100, Stock = 20, CreatedDate = DateTime.Now, Name = "Kalem 1" },
                new Product { Id = 2, CategoryId = 1, Price = 200, Stock = 30, CreatedDate = DateTime.Now, Name = "Kalem 2" },
                new Product { Id = 3, CategoryId = 1, Price = 600, Stock = 60, CreatedDate = DateTime.Now, Name = "Kalem 3" },
                new Product { Id = 4, CategoryId = 2, Price = 600, Stock = 60, CreatedDate = DateTime.Now, Name = "Kitap 1" },
                new Product { Id = 5, CategoryId = 2, Price = 6600, Stock = 320, CreatedDate = DateTime.Now, Name = "Kitap 2" }

                );
        }
    }
}
