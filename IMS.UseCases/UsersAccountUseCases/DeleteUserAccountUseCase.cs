using IMS.UseCases.Interfaces.UserAccountInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.UsersAccountUseCases
{
    public class DeleteUserAccountUseCase : IDeleteUserAccountUseCase
    {
        private readonly IUserAccountRepository userAccountRepository;

        public DeleteUserAccountUseCase(IUserAccountRepository userAccountRepository)
        {
            this.userAccountRepository = userAccountRepository;
        }

        public async Task ExecuteAsync(int userId)
        {
            await this.userAccountRepository.RemoveUserAccountAsync(userId);
        }
    }
}
