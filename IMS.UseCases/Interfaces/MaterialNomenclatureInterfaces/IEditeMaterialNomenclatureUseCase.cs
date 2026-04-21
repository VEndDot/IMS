using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.MaterialNomenclatureInterfaces
{
    public interface IEditeMaterialNomenclatureUseCase
    {
        Task ExecuteAsync(MaterialNomenclature material);
    }
}