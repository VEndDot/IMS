using IMS.CoreBusiness.Entities.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.EFCore.Data.Configurations.Materials
{
    public class MaterialNomenclatureConfiguration : IEntityTypeConfiguration<MaterialNomenclature>
    {
        public void Configure(EntityTypeBuilder<MaterialNomenclature> builder)
        {
            builder.ToTable("Material_nomenclature");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Основные поля
            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Sku)
                .HasColumnName("SKU")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.Gost)
                .HasColumnName("GOST")
                .HasMaxLength(100)
                .IsRequired(false);

            // Числовые поля с точностью
            builder.Property(x => x.CrossSection)
                .HasColumnName("Cross_section")
                .HasColumnType("decimal(10,2)")
                .IsRequired(false);

            builder.Property(x => x.Unit)
                .HasColumnName("Unit")
                .HasMaxLength(10)
                .HasDefaultValue("м");

            builder.Property(x => x.CurrentStock)
                .HasColumnName("Current_stock")
                .HasColumnType("decimal(12,3)")
                .HasDefaultValue(0);

            // Foreign Key
            builder.Property(x => x.TypeId)
                .HasColumnName("Type_id");

            // Связь с типом
            builder.HasOne(n => n.Type)
                .WithMany(t => t.Nomenclatures)
                .HasForeignKey(n => n.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Индексы для производительности
            builder.HasIndex(x => x.Sku)
                .IsUnique()
                .HasDatabaseName("IX_Material_nomenclature_SKU");

            builder.HasIndex(x => new { x.TypeId, x.Name })
                .HasDatabaseName("IX_Material_nomenclature_Type_Name");
        }
    }
}
