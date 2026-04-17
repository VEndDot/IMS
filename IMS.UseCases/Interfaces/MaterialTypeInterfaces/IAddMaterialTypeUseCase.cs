using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.MaterialTypeInterfaces
{
    public interface IAddMaterialTypeUseCase
    {
        Task ExecuteAsync(MaterialType materialType);
    }
}