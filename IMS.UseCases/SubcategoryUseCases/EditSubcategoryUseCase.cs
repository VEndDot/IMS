using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.SubcategoryInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.SubcategoryUseCases
{
    public class EditSubcategoryUseCase : IEditSubcategoryUseCase
    {
        private readonly ISubcategoryRepository subcategoryRepository;

        public EditSubcategoryUseCase(ISubcategoryRepository subcategoryRepository)
        {
            this.subcategoryRepository = subcategoryRepository;
        }

        public async Task ExecuteAsync(Subcategory subcategory)
        {
            await this.subcategoryRepository.UpdateSubcategoryAsync(subcategory);
        }
    }
}
