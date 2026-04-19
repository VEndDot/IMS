using IMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.EFCore.Data.Configurations
{
    public class MaterialWriteOffItemConfiguration : IEntityTypeConfiguration<MaterialWriteOffItem>
    {
        public void Configure(EntityTypeBuilder<MaterialWriteOffItem> builder)
        {
            builder.ToTable("Material_write_off_item");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Foreign Keys
            builder.Property(x => x.WriteOffId)
                .HasColumnName("Write_off_id");

            builder.Property(x => x.NomenclatureId)
                .HasColumnName("Nomenclature_id");

            // Количество
            builder.Property(x => x.Quantity)
                .HasColumnName("Quantity")
                .HasColumnType("decimal(12,3)")
                .IsRequired();

            //связи
            builder.HasOne(i => i.WriteOff)
                .WithMany(w => w.Items)
                .HasForeignKey(i => i.WriteOffId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Nomenclature)
                .WithMany()
                .HasForeignKey(i => i.NomenclatureId)
                .OnDelete(DeleteBehavior.Restrict); // Не удалять материал, если есть в списаниях
        }
    }
}
