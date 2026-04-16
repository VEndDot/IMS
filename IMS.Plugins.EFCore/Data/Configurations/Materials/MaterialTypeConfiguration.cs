using IMS.CoreBusiness.Entities.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.EFCore.Data.Configurations.Materials
{
    public class MaterialTypeConfiguration : IEntityTypeConfiguration<MaterialType>
    {
        public void Configure(EntityTypeBuilder<MaterialType> builder)
        {
            builder.ToTable("Material_type");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasMaxLength(255)
                .IsRequired(false);

            // Foreign Key
            builder.Property(x => x.SubcategoryId)
                .HasColumnName("Subcategory_id");

            // Связь с подкатегорией
            builder.HasOne(t => t.Subcategory)
                .WithMany(s => s.Types)
                .HasForeignKey(t => t.SubcategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь с номенклатурой (Restrict — защита от удаления)
            builder.HasMany(t => t.Nomenclatures)
                .WithOne(n => n.Type)
                .HasForeignKey(n => n.TypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
