using IMS.CoreBusiness.Entities;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.EFCore.Data
{
    public class UserAccountRepository : IUserAccountRepository
    {
        private readonly IMSDbContext db;

        public UserAccountRepository(IMSDbContext db)
        {
            this.db = db;
        }


        public async Task AddUserAccountAsync(UserAccount userAccount)
        {
            await this.db.UserAccounts.AddAsync(userAccount);
            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserAccount>> GetUsersAccountsByNameAsync(string name)
        {
            return await this.db.UserAccounts.Where(u => string.IsNullOrWhiteSpace(name) ||
                            u.FirstName.ToLower().Contains(name.ToLower())).ToListAsync();
                
        }
    }
}
