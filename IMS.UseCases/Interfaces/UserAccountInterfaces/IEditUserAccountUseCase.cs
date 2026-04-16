using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Interfaces.UserAccountInterfaces
{
    public interface IEditUserAccountUseCase
    {
        Task ExecuteAsync(UserAccount userAccount);
    }
}