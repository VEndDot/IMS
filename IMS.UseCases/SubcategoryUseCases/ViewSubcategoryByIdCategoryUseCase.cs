using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.SubcategoryInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.SubcategoryUseCases
{
    public class ViewSubcategoryByIdCategoryUseCase : IViewSubcategoryByIdCategoryUseCase
    {
        private readonly ISubcategoryRepository subcategoryRepository;

        public ViewSubcategoryByIdCategoryUseCase(ISubcategoryRepository subcategoryRepository)
        {
            this.subcategoryRepository = subcategoryRepository;
        }

        public async Task<IEnumerable<Subcategory>> ExecuteAsync(int categoryId)
        {
            return await this.subcategoryRepository.GetSubcategoryByIdCategoryAsync(categoryId);
        }
    }
}
