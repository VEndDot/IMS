using IMS.UseCases.Interfaces.CategoryInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.CategoryUseCases
{
    public class DeleteCategoryUseCase : IDeleteCategoryUseCase
    {
        private readonly ICategoryRepository categoryRepository;

        public DeleteCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task ExecuteAsync(int categoryid)
        {
            await this.categoryRepository.DeleteCategoryAsync(categoryid);
        }
    }
}
