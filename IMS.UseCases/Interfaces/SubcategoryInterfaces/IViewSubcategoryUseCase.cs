using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.SubcategoryInterfaces
{
    public interface IViewSubcategoryUseCase
    {
        Task<IEnumerable<Subcategory>> ExecuteAsync(string name = "");
    }
}