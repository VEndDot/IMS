using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.MaterialNomenclatureInterfaces
{
    public interface IViewMaterialNomenclatureUseCase
    {
        Task<IEnumerable<MaterialNomenclature>> ExecuteAsync(string searchTerm = "");
    }
}