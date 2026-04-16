using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Interfaces.UserAccountInterfaces
{
    public interface IAddUserAccountUseCase
    {
        Task ExecuteAsync(UserAccount usersAccount);
    }
}