using IMS.CoreBusiness.Entities;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.UsersAccountUseCases
{
    public class AddUserAccountUseCase : IAddUserAccountUseCase
    {
        private readonly IUserAccountRepository userAccountRepository;

        public AddUserAccountUseCase(IUserAccountRepository userAccountRepository)
        {
            this.userAccountRepository = userAccountRepository;
        }

        public async Task ExecuteAsync(UserAccount usersAccount)
        {
            await this.userAccountRepository.AddUserAccountAsync(usersAccount);
        }
    }
}
