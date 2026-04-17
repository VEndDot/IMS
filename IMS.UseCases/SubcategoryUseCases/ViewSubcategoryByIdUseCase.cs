using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.SubcategoryInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.SubcategoryUseCases
{
    public class ViewSubcategoryByIdUseCase : IViewSubcategoryByIdUseCase
    {
        private readonly ISubcategoryRepository subcategoryRepository;

        public ViewSubcategoryByIdUseCase(ISubcategoryRepository subcategoryRepository)
        {
            this.subcategoryRepository = subcategoryRepository;
        }

        public async Task<Subcategory?> ExecuteAsync(int subcategoryId)
        {
            return await this.subcategoryRepository.GetSubcategoryByIdAsync(subcategoryId);
        }
    }
}
