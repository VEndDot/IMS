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

        public async Task DeleteMaterialTypeAsync(int materialTypeId)
        {
            var hasNomenclatures = await db.materialNomenclatures
                .AnyAsync(n => n.TypeId == materialTypeId);

            if (hasNomenclatures)
            {
                throw new InvalidOperationException(
                    "Невозможно удалить тип: к нему привязаны материалы. " +
                    "Сначала удалите или перенесите материалы в другой тип.");
            }

            var type = await db.materialTypes.FindAsync(materialTypeId);
            if (type == null)
                throw new InvalidOperationException($"Тип с ID {materialTypeId} не найден");

            db.materialTypes.Remove(type);
            await db.SaveChangesAsync();
        }

        public async Task<MaterialType?> GetMaterialTypeById(int materialId)
        {
            return await this.db.materialTypes
                .Include(t => t.Subcategory)
                    .ThenInclude(s => s.Category)
                .FirstOrDefaultAsync(t => t.Id == materialId);
                
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

        public async Task UpdateMaterialTypeAsync(MaterialType updatedType)
        {
            var existing = await db.materialTypes
                .FirstOrDefaultAsync(t => t.Id == updatedType.Id);

            if (existing == null)
                throw new InvalidOperationException($"Тип с ID {updatedType.Id} не найден");

            var isDuplicate = await db.materialTypes
                .AnyAsync(t => t.Id != updatedType.Id
                            && t.Name == updatedType.Name
                            && t.SubcategoryId == updatedType.SubcategoryId);

            if (isDuplicate)
                throw new InvalidOperationException(
                    $"Тип '{updatedType.Name}' уже существует в выбранной подкатегории");

            existing.Name = updatedType.Name;
            existing.Description = updatedType.Description;

            await db.SaveChangesAsync();
        }
    }
}
