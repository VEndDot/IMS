using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IUserAccountRepository
    {
        Task<IEnumerable<UserAccount>> GetUsersAccountsByNameAsync(string name);

        Task AddUserAccountAsync(UserAccount userAccount);

        Task<UserAccount?> GetUserAccountByIdAsync(int userId);

        Task UpdateUserAccountAsync(UserAccount userAccount);

        Task UpdateUserAccountPasswordAsync(UserAccount userAccount);

        Task RemoveUserAccountAsync(int userId);
    }
}