using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.CategoryInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.CategoryUseCases
{
    public class EditeCategoryUseCase : IEditeCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public EditeCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task ExecuteAsync(Category category)
        {
            await this.categoryRepository.UpdateCategoryAsync(category);
        }
    }
}
