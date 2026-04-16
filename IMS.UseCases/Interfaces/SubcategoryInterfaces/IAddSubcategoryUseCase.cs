using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.SubcategoryInterfaces
{
    public interface IAddSubcategoryUseCase
    {
        Task ExecuteAsync(Subcategory subcategory);
    }
}