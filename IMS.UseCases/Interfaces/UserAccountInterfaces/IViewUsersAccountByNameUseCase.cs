using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Interfaces.UserAccountInterfaces
{
    public interface IViewUsersAccountByNameUseCase
    {
        Task<IEnumerable<UserAccount>> ExecuteAsync(string name = "");
    }
}