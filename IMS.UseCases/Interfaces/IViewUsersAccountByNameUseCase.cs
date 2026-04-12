using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Interfaces
{
    public interface IViewUsersAccountByNameUseCase
    {
        Task<IEnumerable<UserAccount>> ExecuteAsync(string name = "");
    }
}