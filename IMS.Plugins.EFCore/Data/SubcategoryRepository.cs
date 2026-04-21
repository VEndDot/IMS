using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.EFCore.Data
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly IMSDbContext db;

        public SubcategoryRepository(IMSDbContext db)
        {
            this.db = db;
        }

        public async Task AddSubcategoryAcync(Subcategory subcategory)
        {
            await this.db.Subcategories.AddAsync(subcategory);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteSubcategoryAsync(int subcategoryId)
        {
            var hasTypes = await this.db.materialTypes
                .AnyAsync(t => t.SubcategoryId == subcategoryId);

            if (hasTypes)
            {
                throw new InvalidOperationException(
                    "Невозможно удалить подкатегорию: к ней привязаны типы материалов. " +
                    "Сначала удалите или перенесите типы в другую подкатегорию.");
            }

            var subcategory = await this.db.Subcategories.FindAsync(subcategoryId);
            if (subcategory == null)
                throw new InvalidOperationException($"Подкатегория с ID {subcategoryId} не найдена");

            this.db.Subcategories.Remove(subcategory);
            await this.db.SaveChangesAsync();
        }

        public async Task<Subcategory?> GetSubcategoryByIdAsync(int subcategoryId)
        {
            return await this.db.Subcategories.FindAsync(subcategoryId);
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategoryByIdCategoryAsync(int categoryId)
        {
            var query = this.db.Subcategories.Include(s => s.Category).Where(s => s.CategoryId == categoryId);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategoryByNameAsync(string name)
        {
            var query = this.db.Subcategories.Include(s => s.Category).AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(s => s.Name.ToLower().Contains(name.ToLower()) || s.Category.Name.ToLower().Contains(name.ToLower()));
            }

            return await query.ToListAsync();
        }

        public async Task UpdateSubcategoryAsync(Subcategory updatedSubcategory)
        {
            var existing = await this.db.Subcategories
                .FirstOrDefaultAsync(s => s.Id == updatedSubcategory.Id);

            if (existing == null)
                throw new InvalidOperationException($"Подкатегория с ID {updatedSubcategory.Id} не найдена");

            var isDuplicate = await this.db.Subcategories
                .AnyAsync(s => s.Id != updatedSubcategory.Id
                            && s.Name == updatedSubcategory.Name
                            && s.CategoryId == updatedSubcategory.CategoryId);

            if (isDuplicate)
                throw new InvalidOperationException(
                    $"Подкатегория '{updatedSubcategory.Name}' уже существует в выбранной категории");

            existing.Name = updatedSubcategory.Name;

            await this.db.SaveChangesAsync();
        }
    }
}
