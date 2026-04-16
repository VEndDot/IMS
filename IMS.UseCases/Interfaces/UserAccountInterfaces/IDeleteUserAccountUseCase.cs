namespace IMS.UseCases.Interfaces.UserAccountInterfaces
{
    public interface IDeleteUserAccountUseCase
    {
        Task ExecuteAsync(int userId);
    }
}