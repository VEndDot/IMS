using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.SubcategoryInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.SubcategoryUseCases
{
    public class AddSubcategoryUseCase : IAddSubcategoryUseCase
    {
        private readonly ISubcategoryRepository subcategoryRepository;

        public AddSubcategoryUseCase(ISubcategoryRepository subcategoryRepository)
        {
            this.subcategoryRepository = subcategoryRepository;
        }

        public async Task ExecuteAsync(Subcategory subcategory)
        {
            await this.subcategoryRepository.AddSubcategoryAcync(subcategory);
        }
    }
}
