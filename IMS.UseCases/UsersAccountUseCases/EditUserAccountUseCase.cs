using IMS.CoreBusiness.Entities;
using IMS.UseCases.Interfaces.UserAccountInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.UsersAccountUseCases
{
    public class EditUserAccountUseCase : IEditUserAccountUseCase
    {
        private readonly IUserAccountRepository userAccountRepository;

        public EditUserAccountUseCase(IUserAccountRepository userAccountRepository)
        {
            this.userAccountRepository = userAccountRepository;
        }

        public async Task ExecuteAsync(UserAccount userAccount)
        {
            await this.userAccountRepository.UpdateUserAccountAsync(userAccount);
        }
    }
}
