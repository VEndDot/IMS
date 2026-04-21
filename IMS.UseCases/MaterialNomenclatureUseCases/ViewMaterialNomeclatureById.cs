using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.MaterialNomenclatureInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.MaterialNomenclatureUseCases
{
    public class ViewMaterialNomeclatureById : IViewMaterialNomeclatureById
    {
        private readonly IMaterialNomenclatureRepository materialNomenclatureRepository;

        public ViewMaterialNomeclatureById(IMaterialNomenclatureRepository materialNomenclatureRepository)
        {
            this.materialNomenclatureRepository = materialNomenclatureRepository;
        }

        public async Task<MaterialNomenclature?> ExecuteAsync(int materialId)
        {
            return await this.materialNomenclatureRepository.GetMaterialNomenclatureById(materialId);
        }
    }
}
