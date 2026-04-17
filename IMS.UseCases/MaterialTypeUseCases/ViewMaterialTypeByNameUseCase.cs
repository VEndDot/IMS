using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.MaterialTypeInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.MaterialTypeUseCases
{
    public class ViewMaterialTypeByNameUseCase : IViewMaterialTypeByNameUseCase
    {
        private readonly IMaterialTypeRepository materialTypeRepository;

        public ViewMaterialTypeByNameUseCase(IMaterialTypeRepository materialTypeRepository)
        {
            this.materialTypeRepository = materialTypeRepository;
        }

        public async Task<IEnumerable<MaterialType>> ExecuteAsync(string name = "")
        {
            return await this.materialTypeRepository.GetMaterialTypeByNameAsync(name);
        }
    }
}
