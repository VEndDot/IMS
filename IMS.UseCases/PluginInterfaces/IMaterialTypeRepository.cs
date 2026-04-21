using IMS.CoreBusiness.Entities.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IMaterialTypeRepository
    {
        Task AddMaterialTypeAsync(MaterialType materialType);

        Task UpdateMaterialTypeAsync(MaterialType materialType);

        Task DeleteMaterialTypeAsync(int materialTypeId);

        Task<IEnumerable<MaterialType>> GetMaterialTypeByNameAsync(string name);

        Task<IEnumerable<MaterialType>> GetMaterialTypesByIdSubcategoryAsync(int subcategoryId);

        Task<MaterialType?> GetMaterialTypeById(int materialId);
    }
}
