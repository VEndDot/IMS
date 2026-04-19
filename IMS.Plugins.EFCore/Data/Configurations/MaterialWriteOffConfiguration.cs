using IMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.EFCore.Data.Configurations
{
    public class MaterialWriteOffConfiguration : IEntityTypeConfiguration<MaterialWriteOff>
    {
        public void Configure(EntityTypeBuilder<MaterialWriteOff> builder)
        {
            builder.ToTable("Material_write_off");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Поля
            builder.Property(x => x.Reason)
                .HasColumnName("Reason")
                .HasMaxLength(300)
                .IsUnicode()
                .IsRequired();

            builder.Property(x => x.MasterId)
                .HasColumnName("Master_id");

            builder.Property(x => x.WriteOffDate)
                .HasColumnName("Write_off_date")
                .HasColumnType("datetime2")
                .IsRequired();

            // Связь с пользователем
            builder.HasOne(w => w.Master)
                .WithMany()
                .HasForeignKey(w => w.MasterId)
                .OnDelete(DeleteBehavior.Restrict); // Не удалять мастера, если есть списания

            // Связь со строками
            builder.HasMany(w => w.Items)
                .WithOne(i => i.WriteOff)
                .HasForeignKey(i => i.WriteOffId)
                .OnDelete(DeleteBehavior.Cascade); // Удалил списание → удалились строки

            // Индексы для отчётов
            builder.HasIndex(x => x.MasterId)
                .HasDatabaseName("IX_Material_write_off_Master_id");

            builder.HasIndex(x => x.WriteOffDate)
                .HasDatabaseName("IX_Material_write_off_Date");

        }
    }
}
