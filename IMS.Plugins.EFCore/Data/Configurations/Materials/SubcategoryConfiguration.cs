using IMS.CoreBusiness.Entities.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.EFCore.Data.Configurations.Materials
{
    public class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.ToTable("Material_subcategory");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            // внешний ключ
            builder.Property(x => x.CategoryId)
                .HasColumnName("Category_id");

            // связь с категрорией
            builder.HasOne(s => s.Category)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // связь с типами
            builder.HasMany(s => s.Types)
                   .WithOne(t => t.Subcategory)
                   .HasForeignKey(t => t.SubcategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
