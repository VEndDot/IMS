using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.CategoryInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.CategoryUseCases
{
    public class ViewCategoryByNameUseCase : IViewCategoryByNameUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public ViewCategoryByNameUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> ExecuteAsync(string name = "")
        {
            return await this.categoryRepository.GetCategoriesByNameAsync(name);
        }
    }
}
