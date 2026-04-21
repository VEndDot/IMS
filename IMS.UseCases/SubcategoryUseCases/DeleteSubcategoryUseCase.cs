using IMS.UseCases.Interfaces.SubcategoryInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.SubcategoryUseCases
{
    public class DeleteSubcategoryUseCase : IDeleteSubcategoryUseCase
    {
        private readonly ISubcategoryRepository subcategoryRepository;

        public DeleteSubcategoryUseCase(ISubcategoryRepository subcategoryRepository)
        {
            this.subcategoryRepository = subcategoryRepository;
        }

        public async Task ExecuteAsync(int subcategoryId)
        {
            await this.subcategoryRepository.DeleteSubcategoryAsync(subcategoryId);
        }
    }
}
