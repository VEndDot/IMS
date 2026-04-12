using IMS.CoreBusiness.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.EFCore.Data.Configurations
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            // Имя таблицы
            builder.ToTable("User_account");

            // Первичный ключ
            builder.HasKey(x => x.Id);

            // Настройка автоинкремента (identity)
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Настройка полей
            builder.Property(x => x.FirstName)
                .HasColumnName("First_name")
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(x => x.Password)
                .HasColumnName("Password")
                .HasMaxLength(100);

            builder.Property(x => x.Role)
                .HasColumnName("Role")
                .HasMaxLength(20);
        }
    }
}
