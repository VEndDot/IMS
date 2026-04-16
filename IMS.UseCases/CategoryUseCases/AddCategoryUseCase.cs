using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.CategoryInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.CategoryUseCases
{
    public class AddCategoryUseCase : IAddCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public AddCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task ExecuteAsync(Category category)
        {
            await this.categoryRepository.AddCategoryAsync(category);
        }
    }
}
