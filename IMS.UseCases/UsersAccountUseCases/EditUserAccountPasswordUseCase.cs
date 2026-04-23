using IMS.CoreBusiness.Entities;
using IMS.UseCases.Interfaces.UserAccountInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.UsersAccountUseCases
{
    public class EditUserAccountPasswordUseCase : IEditUserAccountPasswordUseCase
    {
        private readonly IUserAccountRepository userAccountRepository;

        public EditUserAccountPasswordUseCase(IUserAccountRepository userAccountRepository)
        {
            this.userAccountRepository = userAccountRepository;
        }

        public async Task ExecuteAsync(UserAccount userAccount)
        {
            await this.userAccountRepository.UpdateUserAccountPasswordAsync(userAccount);
        }
    }
}
