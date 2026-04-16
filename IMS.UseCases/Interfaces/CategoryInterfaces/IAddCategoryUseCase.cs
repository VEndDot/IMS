using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.CategoryInterfaces
{
    public interface IAddCategoryUseCase
    {
        Task ExecuteAsync(Category category);
    }
}