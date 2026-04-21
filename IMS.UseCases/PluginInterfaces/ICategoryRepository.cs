using IMS.CoreBusiness.Entities.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.PluginInterfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesByNameAsync(string name);

        Task<Category?> GetCategoriesByIdAsync(int categoryId);

        Task AddCategoryAsync(Category category);

        Task UpdateCategoryAsync(Category category);

        Task DeleteCategoryAsync(int categoryId);
    }
}
