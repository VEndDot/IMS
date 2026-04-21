using IMS.CoreBusiness.Entities.Materials;

namespace IMS.UseCases.Interfaces.SubcategoryInterfaces
{
    public interface IEditSubcategoryUseCase
    {
        Task ExecuteAsync(Subcategory subcategory);
    }
}