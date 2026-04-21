using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.MaterialNomenclatureInterfaces
{
    public interface IViewMaterialNomeclatureById
    {
        Task<MaterialNomenclature?> ExecuteAsync(int materialId);
    }
}