namespace IMS.UseCases.Interfaces.CategoryInterfaces
{
    public interface IDeleteCategoryUseCase
    {
        Task ExecuteAsync(int categoryid);
    }
}