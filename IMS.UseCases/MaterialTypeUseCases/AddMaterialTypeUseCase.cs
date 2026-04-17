using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.MaterialTypeInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.MaterialTypeUseCases
{
    public class AddMaterialTypeUseCase : IAddMaterialTypeUseCase
    {
        private readonly IMaterialTypeRepository materialTypeRepository;

        public AddMaterialTypeUseCase(IMaterialTypeRepository materialTypeRepository)
        {
            this.materialTypeRepository = materialTypeRepository;
        }

        public async Task ExecuteAsync(MaterialType materialType)
        {
            await this.materialTypeRepository.AddMaterialTypeAsync(materialType);
        }
    }
}
