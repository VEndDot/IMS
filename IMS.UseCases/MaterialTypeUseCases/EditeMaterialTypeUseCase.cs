using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.MaterialTypeInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.MaterialTypeUseCases
{
    public class EditeMaterialTypeUseCase : IEditeMaterialTypeUseCase
    {
        private readonly IMaterialTypeRepository materialTypeRepository;
        public EditeMaterialTypeUseCase(IMaterialTypeRepository materialTypeRepository)
        {
            this.materialTypeRepository = materialTypeRepository;
        }

        public async Task ExecuteAsync(MaterialType materialType)
        {
            await this.materialTypeRepository.UpdateMaterialTypeAsync(materialType);
        }
    }
}
