using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Interfaces.UserAccountInterfaces
{
    public interface IViewUserAccountByIdUseCase
    {
        Task<UserAccount?> ExecuteAsync(int userId);
    }
}