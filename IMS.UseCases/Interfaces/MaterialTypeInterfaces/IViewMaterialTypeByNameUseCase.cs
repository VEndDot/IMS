using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.MaterialTypeInterfaces
{
    public interface IViewMaterialTypeByNameUseCase
    {
        Task<IEnumerable<MaterialType>> ExecuteAsync(string name = "");
    }
}