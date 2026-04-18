using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.MaterialTypeInterfaces
{
    public interface IViewMaterialTypesByIdSubcategoryUseCase
    {
        Task<IEnumerable<MaterialType>> ExecuteAsync(int subcategoryId);
    }
}