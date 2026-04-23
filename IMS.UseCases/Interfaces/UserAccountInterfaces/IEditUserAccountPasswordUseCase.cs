using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Interfaces.UserAccountInterfaces
{
    public interface IEditUserAccountPasswordUseCase
    {
        Task ExecuteAsync(UserAccount userAccount);
    }
}