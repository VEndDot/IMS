using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.MaterialTypeInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.MaterialTypeUseCases
{
    public class ViewMaterialTypesByIdSubcategoryUseCase : IViewMaterialTypesByIdSubcategoryUseCase
    {
        private readonly IMaterialTypeRepository materialTypeRepository;

        public ViewMaterialTypesByIdSubcategoryUseCase(IMaterialTypeRepository materialTypeRepository)
        {
            this.materialTypeRepository = materialTypeRepository;
        }

        public async Task<IEnumerable<MaterialType>> ExecuteAsync(int subcategoryId)
        {
            return await this.materialTypeRepository.GetMaterialTypesByIdSubcategoryAsync(subcategoryId);
        }
    }
}
