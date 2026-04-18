using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.EFCore.Data
{
    public class MaterialTypeRepository : IMaterialTypeRepository
    {
        private readonly IMSDbContext db;

        public MaterialTypeRepository(IMSDbContext db)
        {
            this.db = db;
        }

        public async Task AddMaterialTypeAsync(MaterialType materialType)
        {
            var exists = await this.db.materialTypes
                .AnyAsync(mt => mt.SubcategoryId == materialType.SubcategoryId &&
                                mt.Name.ToLower() == materialType.Name.ToLower());

            if (exists)
            {
                throw new InvalidOperationException(
                    $"Тип материала с наименованием '{materialType.Name}' " +
                    $"в выбранной подкатегории уже существует");
            }

            await this.db.materialTypes.AddAsync(materialType);
            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<MaterialType>> GetMaterialTypeByNameAsync(string name)
        {
            var query = this.db.materialTypes.Include(mt => mt.Subcategory).AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(mt => mt.Name.ToLower().Contains(name.ToLower()) || 
                                          mt.Subcategory.Name.ToLower().Contains(name.ToLower()));
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<MaterialType>> GetMaterialTypesByIdSubcategoryAsync(int subcategoryId)
        {
            return await this.db.materialTypes.Include(mt => mt.Subcategory)
                .ThenInclude(s => s!.Category)
                .Where(mt => mt.SubcategoryId == subcategoryId)
                .ToListAsync();
        }
    }
}
