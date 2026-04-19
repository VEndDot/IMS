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
    }
}
