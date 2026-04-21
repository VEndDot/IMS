using IMS.UseCases.Interfaces.MaterialTypeInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.MaterialTypeUseCases
{
    public class DeleteMaterialTypeUseCase : IDeleteMaterialTypeUseCase
    {
        private readonly IMaterialTypeRepository materialTypeRepository;

        public DeleteMaterialTypeUseCase(IMaterialTypeRepository materialTypeRepository)
        {
            this.materialTypeRepository = materialTypeRepository;
        }

        public async Task ExecuteAsync(int materialTypeId)
        {
            await this.materialTypeRepository.DeleteMaterialTypeAsync(materialTypeId);
        }
    }
}
