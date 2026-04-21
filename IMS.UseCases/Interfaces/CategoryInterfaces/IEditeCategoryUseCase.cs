using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.CategoryInterfaces
{
    public interface IEditeCategoryUseCase
    {
        Task ExecuteAsync(Category category);
    }
}