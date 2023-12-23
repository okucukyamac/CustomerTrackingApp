using CustomerTracking.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerTracking.Repository.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(a=>a.Id);
            builder.Property(a=>a.Id).UseIdentityColumn();
            builder.Property(a=>a.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("Categories");
        }
    }
}
