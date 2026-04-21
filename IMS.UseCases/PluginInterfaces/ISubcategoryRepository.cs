using IMS.CoreBusiness.Entities.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.PluginInterfaces
{
    public interface ISubcategoryRepository
    {
        Task AddSubcategoryAcync(Subcategory subcategory);

        Task<IEnumerable<Subcategory>> GetSubcategoryByNameAsync(string name);

        Task DeleteSubcategoryAsync(int subcategoryId);

        Task<Subcategory?> GetSubcategoryByIdAsync(int subcategoryId);

        Task<IEnumerable<Subcategory>> GetSubcategoryByIdCategoryAsync(int categoryId);

        Task UpdateSubcategoryAsync(Subcategory subcategory);

    }
}
