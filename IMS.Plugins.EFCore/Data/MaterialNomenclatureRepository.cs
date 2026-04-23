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

        public async Task DeleteMaterialAsync(int materialId)
        {
            // 1. Проверяем, используется ли материал в списаниях
            var isUsed = await this.db.MaterialWriteOffItems
                .AnyAsync(i => i.NomenclatureId == materialId);

            if (isUsed)
            {
                throw new InvalidOperationException(
                    $"Невозможно удалить материал: он уже использовался в списаниях.");
            }

            // 2. Находим и удаляем
            var material = await this.db.materialNomenclatures
                .FirstOrDefaultAsync(m => m.Id == materialId);

            if (material == null)
            {
                throw new InvalidOperationException($"Материал с ID {materialId} не найден");
            }

            this.db.materialNomenclatures.Remove(material);
            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<MaterialNomenclature>> GetMaterialNomenclature(string searchTerm = "")
        {
            var query = this.db.materialNomenclatures
                .Include(mn => mn.Type)                          // Тип материала
                .ThenInclude(t => t.Subcategory)                 // Подкатегория типа
                .ThenInclude(s => s.Category)                    // Категория подкатегории
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim().ToLower();

                query = query.Where(mn =>
                    // 1. Поиск по имени номенклатуры
                    mn.Name.ToLower().Contains(term) ||
                    // 2. Поиск по артикулу (SKU)
                    (mn.Sku != null && mn.Sku.ToLower().Contains(term)) ||
                    // 3. Поиск по названию типа
                    mn.Type.Name.ToLower().Contains(term) ||
                    // 4. Поиск по названию подкатегории
                    (mn.Type.Subcategory.Name.ToLower().Contains(term)) ||
                    // 5. Поиск по названию категории
                    (mn.Type.Subcategory.Category.Name.ToLower().Contains(term))
                );
            }

            return await query
                .AsNoTracking()          // Оптимизация: если данные только для чтения
                .OrderBy(mn => mn.Name)  // Сортировка для предсказуемого результата
                .ToListAsync();
        }

        public async Task<IEnumerable<MaterialNomenclature>> GetMaterialNomenclatureByCurrentStockAsync(string searchTerm = "")
        {
            var query = this.db.materialNomenclatures
                .Include(mn => mn.Type)                          // Тип материала
                .ThenInclude(t => t.Subcategory)                 // Подкатегория типа
                .ThenInclude(s => s.Category)                    // Категория подкатегории
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var term = searchTerm.Trim().ToLower();

                query = query.Where(mn =>
                    // 1. Поиск по имени номенклатуры
                    mn.Name.ToLower().Contains(term) ||
                    // 2. Поиск по артикулу (SKU)
                    (mn.Sku != null && mn.Sku.ToLower().Contains(term)) ||
                    // 3. Поиск по названию типа
                    mn.Type.Name.ToLower().Contains(term) ||
                    // 4. Поиск по названию подкатегории
                    (mn.Type.Subcategory.Name.ToLower().Contains(term)) ||
                    // 5. Поиск по названию категории
                    (mn.Type.Subcategory.Category.Name.ToLower().Contains(term))
                );
            }

            return await query
                .AsNoTracking()          // Оптимизация: если данные только для чтения
                .OrderBy(mn => mn.CurrentStock)  // Сортировка для по количеству
                .ToListAsync();
        }

        public async Task<MaterialNomenclature?> GetMaterialNomenclatureById(int materialId)
        {
            return await this.db.materialNomenclatures
                .Include(m => m.Type)
                    .ThenInclude(t => t.Subcategory)
                        .ThenInclude(s => s.Category)
                .FirstOrDefaultAsync(m => m.Id == materialId);
        }

        public async Task UpdateMaterialNomeclatureAsync(MaterialNomenclature material)
        {
            var existing = await this.db.materialNomenclatures
                .FirstOrDefaultAsync(m => m.Id == material.Id);

            if (existing == null)
            {
                throw new InvalidOperationException($"Материал с ID {material.Id} не найден");
            }

            // Обновление редактируемых полей
            existing.Name = material.Name;
            existing.Sku = material.Sku;
            existing.Gost = material.Gost;
            existing.CrossSection = material.CrossSection;
            existing.Unit = material.Unit;
            existing.CurrentStock = material.CurrentStock;

            if (material.TypeId > 0 && material.TypeId != existing.TypeId)
            { 
                existing.TypeId = material.TypeId;
            }

            await this.db.SaveChangesAsync();
        }
    }
}
