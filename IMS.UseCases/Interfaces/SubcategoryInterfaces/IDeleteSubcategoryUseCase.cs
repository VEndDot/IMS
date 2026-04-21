namespace IMS.UseCases.Interfaces.SubcategoryInterfaces
{
    public interface IDeleteSubcategoryUseCase
    {
        Task ExecuteAsync(int subcategoryId);
    }
}