using IMS.CoreBusiness.Entities;

namespace IMS.UseCases.Interfaces
{
    public interface IAddUserAccountUseCase
    {
        Task ExecuteAsync(UserAccount usersAccount);
    }
}