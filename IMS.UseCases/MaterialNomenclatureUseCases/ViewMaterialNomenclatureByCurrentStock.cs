using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.Interfaces.MaterialNomenclatureInterfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.MaterialNomenclatureUseCases
{
    public class ViewMaterialNomenclatureByCurrentStock : IViewMaterialNomenclatureByCurrentStock
    {
        private readonly IMaterialNomenclatureRepository materialNomenclatureRepository;

        public ViewMaterialNomenclatureByCurrentStock(IMaterialNomenclatureRepository materialNomenclatureRepository)
        {
            this.materialNomenclatureRepository = materialNomenclatureRepository;
        }

        public async Task<IEnumerable<MaterialNomenclature>> ExecuteAsync(string searchTerm = "")
        {
            return await this.materialNomenclatureRepository.GetMaterialNomenclatureByCurrentStockAsync(searchTerm);
        }
    }
}
