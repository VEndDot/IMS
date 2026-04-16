using IMS.CoreBusiness.Entities;
using IMS.CoreBusiness.Entities.Materials;
using IMS.Plugins.EFCore.Data.Configurations;
using IMS.Plugins.EFCore.Data.Configurations.Materials;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.EFCore.Data
{
    public class IMSDbContext : DbContext
    {
        public IMSDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<MaterialType> materialTypes { get; set; }
        public DbSet<MaterialNomenclature> materialNomenclatures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SubcategoryConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialNomenclatureConfiguration());
        }

    }
}
