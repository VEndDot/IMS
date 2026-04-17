using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.SubcategoryInterfaces
{
    public interface IViewSubcategoryByIdUseCase
    {
        Task<Subcategory?> ExecuteAsync(int subcategoryId);
    }
}