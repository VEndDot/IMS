using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.MaterialNomenclatureInterfaces
{
    public interface IAddMaterialNomenclatureUseCase
    {
        Task ExecuteAsync(MaterialNomenclature materialNomenclature);
    }
}