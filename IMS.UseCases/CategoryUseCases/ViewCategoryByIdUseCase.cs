using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.CategoryInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.CategoryUseCases
{
    public class ViewCategoryByIdUseCase : IViewCategoryByIdUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public ViewCategoryByIdUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Category?> ExecuteAsync(int categoryId)
        {
            return await this.categoryRepository.GetCategoriesByIdAsync(categoryId);
        }
    }
}
