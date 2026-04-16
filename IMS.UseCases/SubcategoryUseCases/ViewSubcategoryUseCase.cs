using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.SubcategoryInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.SubcategoryUseCases
{
    public class ViewSubcategoryUseCase : IViewSubcategoryUseCase
    {
        private readonly ISubcategoryRepository subcategoryRepository;

        public ViewSubcategoryUseCase(ISubcategoryRepository subcategoryRepository)
        {
            this.subcategoryRepository = subcategoryRepository;
        }

        public async Task<IEnumerable<Subcategory>> ExecuteAsync(string name = "")
        {
            return await this.subcategoryRepository.GetSubcategoryByNameAsync(name);
        }
    }
}
