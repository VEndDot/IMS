using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IUserAccountRepository
    {
        Task<IEnumerable<UserAccount>> GetUsersAccountsByNameAsync(string name);

        Task AddUserAccountAsync(UserAccount userAccount);
    }
}