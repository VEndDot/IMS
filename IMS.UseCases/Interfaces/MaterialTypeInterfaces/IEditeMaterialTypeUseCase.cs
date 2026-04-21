using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.MaterialTypeInterfaces
{
    public interface IEditeMaterialTypeUseCase
    {
        Task ExecuteAsync(MaterialType materialType);
    }
}