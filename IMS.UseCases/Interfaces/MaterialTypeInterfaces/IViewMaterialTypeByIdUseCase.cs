using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.MaterialTypeInterfaces
{
    public interface IViewMaterialTypeByIdUseCase
    {
        Task<MaterialType?> ExecuteAsync(int materialId);
    }
}