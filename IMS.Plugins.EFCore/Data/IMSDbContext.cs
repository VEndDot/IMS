using IMS.CoreBusiness.Entities;
using IMS.Plugins.EFCore.Data.Configurations;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
        }

    }
}
