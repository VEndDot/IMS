using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.MaterialNomenclatureInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.MaterialNomenclatureUseCases
{
    public class AddMaterialNomenclatureUseCase : IAddMaterialNomenclatureUseCase
    {
        private readonly IMaterialNomenclatureRepository materialNomenclatureRepository;

        public AddMaterialNomenclatureUseCase(IMaterialNomenclatureRepository materialNomenclatureRepository)
        {
            this.materialNomenclatureRepository = materialNomenclatureRepository;
        }

        public async Task ExecuteAsync(MaterialNomenclature materialNomenclature)
        {
            await this.materialNomenclatureRepository.AddMaterialNomenclatureAsync(materialNomenclature);
        }
    }
}
