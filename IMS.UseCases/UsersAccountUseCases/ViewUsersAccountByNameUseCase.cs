using IMS.CoreBusiness.Entities;
using IMS.UseCases.Interfaces.UserAccountInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.UsersAccountUseCases
{
    public class ViewUsersAccountByNameUseCase : IViewUsersAccountByNameUseCase
    {
        private readonly IUserAccountRepository userAccountRepository;

        public ViewUsersAccountByNameUseCase(IUserAccountRepository userAccountRepository)
        {
            this.userAccountRepository = userAccountRepository;
        }


        public async Task<IEnumerable<UserAccount>> ExecuteAsync(string name = "")
        {
            return await this.userAccountRepository.GetUsersAccountsByNameAsync(name);
        }
    }
}
