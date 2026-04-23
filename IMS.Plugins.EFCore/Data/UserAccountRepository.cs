using IMS.CoreBusiness.Entities;
using IMS.CoreBusiness.Services;
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

        public async Task<UserAccount?> GetUserAccountByIdAsync(int userId)
        {
            return await this.db.UserAccounts.FindAsync(userId);
        }

        public async Task<IEnumerable<UserAccount>> GetUsersAccountsByNameAsync(string name)
        {
            return await this.db.UserAccounts.Where(u => string.IsNullOrWhiteSpace(name) ||
                            u.FirstName.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task RemoveUserAccountAsync(int userId)
        {
            var user = await this.db.UserAccounts.FindAsync(userId);
            if (user is not null)
            { 
                this.db.UserAccounts.Remove(user);
                await this.db.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAccountAsync(UserAccount userAccount)
        {
            var user = await this.db.UserAccounts.FindAsync(userAccount.Id);
            if (user is not null)
            {
                user.FirstName = userAccount.FirstName;
                user.Role = userAccount.Role;
                user.Password = userAccount.Password;

                await this.db.SaveChangesAsync();
            }
                
        }

        public async Task UpdateUserAccountPasswordAsync(UserAccount userAccount)
        {
            var user = await this.db.UserAccounts.FindAsync(userAccount.Id);
            if (user is not null)
            {
                user.FirstName = userAccount.FirstName;
                user.Role = userAccount.Role;

                if (!string.IsNullOrWhiteSpace(userAccount.Password))
                {
                    //user.Password = userAccount.Password;
                    user.Password = PasswordHasher.Hash(userAccount.Password);
                }

                await this.db.SaveChangesAsync();
            }
        }
    }
}
