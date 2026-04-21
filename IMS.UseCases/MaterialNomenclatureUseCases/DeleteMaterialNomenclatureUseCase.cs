using IMS.UseCases.Interfaces.MaterialNomenclatureInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.MaterialNomenclatureUseCases
{
    public class DeleteMaterialNomenclatureUseCase : IDeleteMaterialNomenclatureUseCase
    {
        private readonly IMaterialNomenclatureRepository materialNomenclatureRepository;

        public DeleteMaterialNomenclatureUseCase(IMaterialNomenclatureRepository materialNomenclatureRepository)
        {
            this.materialNomenclatureRepository = materialNomenclatureRepository;
        }

        public async Task ExecuteAsync(int materialId)
        {
            await this.materialNomenclatureRepository.DeleteMaterialAsync(materialId);
        }
    }
}
