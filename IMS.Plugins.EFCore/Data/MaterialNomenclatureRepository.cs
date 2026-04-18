using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.EFCore.Data
{
    public class MaterialNomenclatureRepository : IMaterialNomenclatureRepository
    {
        private readonly IMSDbContext db;

        public MaterialNomenclatureRepository(IMSDbContext db)
        {
            this.db = db;
        }

        public async Task AddMaterialNomenclatureAsync(MaterialNomenclature materialNomenclature)
        {
            var exists = await this.db.materialNomenclatures
                .AnyAsync(mn => mn.Name == materialNomenclature.Name &&
                                mn.Sku == materialNomenclature.Sku &&
                                mn.TypeId == materialNomenclature.TypeId);

            if (exists)
            {
                throw new InvalidOperationException(
                    $"Материал '{materialNomenclature.Name}' (SKU: {materialNomenclature.Sku ?? "N/A"})" +
                    $"для типа ID {materialNomenclature.TypeId} уже существует");
            }

            await this.db.materialNomenclatures.AddAsync(materialNomenclature);
            await this.db.SaveChangesAsync();
        }
    }
}
