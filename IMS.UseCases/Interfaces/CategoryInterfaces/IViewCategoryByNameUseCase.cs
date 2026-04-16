using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.CategoryInterfaces
{
    public interface IViewCategoryByNameUseCase
    {
        Task<IEnumerable<Category>> ExecuteAsync(string name = "");
    }
}