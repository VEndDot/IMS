using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.CategoryInterfaces
{
    public interface IViewCategoryByIdUseCase
    {
        Task<Category?> ExecuteAsync(int categoryId);
    }
}