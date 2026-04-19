using IMS.CoreBusiness.Entities.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IMaterialNomenclatureRepository
    {
        Task AddMaterialNomenclatureAsync(MaterialNomenclature materialNomenclature);
        Task<IEnumerable<MaterialNomenclature>> GetMaterialNomenclature(string searchTerm = "");

    }
}
