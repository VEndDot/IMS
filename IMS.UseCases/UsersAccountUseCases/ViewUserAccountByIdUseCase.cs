using IMS.CoreBusiness.Entities;
using IMS.UseCases.Interfaces.UserAccountInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.UsersAccountUseCases
{
    public class ViewUserAccountByIdUseCase : IViewUserAccountByIdUseCase
    {
        private readonly IUserAccountRepository userAccountRepository;

        public ViewUserAccountByIdUseCase(IUserAccountRepository userAccountRepository)
        {
            this.userAccountRepository = userAccountRepository;
        }

        public async Task<UserAccount?> ExecuteAsync(int userId)
        {
            return await this.userAccountRepository.GetUserAccountByIdAsync(userId);
        }
    }
}
