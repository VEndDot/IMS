using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.MaterialTypeInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.MaterialTypeUseCases
{
    public class ViewMaterialTypeByIdUseCase : IViewMaterialTypeByIdUseCase
    {
        private readonly IMaterialTypeRepository materialTypeRepository;

        public ViewMaterialTypeByIdUseCase(IMaterialTypeRepository materialTypeRepository)
        {
            this.materialTypeRepository = materialTypeRepository;
        }

        public async Task<MaterialType?> ExecuteAsync(int materialId)
        {
            return await this.materialTypeRepository.GetMaterialTypeById(materialId);
        }
    }
}
