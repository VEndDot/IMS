using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.SubcategoryInterfaces
{
    public interface IViewSubcategoryByIdCategoryUseCase
    {
        Task<IEnumerable<Subcategory>> ExecuteAsync(int categoryId);
    }
}