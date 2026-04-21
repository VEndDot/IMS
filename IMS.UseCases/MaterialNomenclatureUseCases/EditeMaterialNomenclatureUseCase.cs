using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.MaterialNomenclatureInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.MaterialNomenclatureUseCases
{
    public class EditeMaterialNomenclatureUseCase : IEditeMaterialNomenclatureUseCase
    {
        private readonly IMaterialNomenclatureRepository materialNomenclatureRepository;

        public EditeMaterialNomenclatureUseCase(IMaterialNomenclatureRepository materialNomenclatureRepository)
        {
            this.materialNomenclatureRepository = materialNomenclatureRepository;
        }

        public async Task ExecuteAsync(MaterialNomenclature material)
        {
            await this.materialNomenclatureRepository.UpdateMaterialNomeclatureAsync(material);
        }
    }
}
