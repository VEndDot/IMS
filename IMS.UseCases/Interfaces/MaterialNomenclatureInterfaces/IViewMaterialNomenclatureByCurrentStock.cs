using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.MaterialNomenclatureInterfaces
{
    public interface IViewMaterialNomenclatureByCurrentStock
    {
        Task<IEnumerable<MaterialNomenclature>> ExecuteAsync(string searchTerm = "");
    }
}