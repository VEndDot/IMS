using IMS.CoreBusiness.Entities.Materials;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.EFCore.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMSDbContext db;

        public CategoryRepository(IMSDbContext db)
        {
            this.db = db;
        }

        public async Task AddCategoryAsync(Category category)
        {
            if (await this.db.Categories.AnyAsync(c => c.Name.ToLower() == category.Name.ToLower()))
                throw new InvalidOperationException("Категория с таким именем уже существует");
            await this.db.Categories.AddAsync(category);
            await this.db.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await this.db.Categories.FindAsync(categoryId);
            if (category == null)
                throw new InvalidOperationException($"Категория с Id={categoryId} не найдена");

            // 👇 Проверка на связанные подкатегории (каскадное удаление может быть опасным!)
            var hasSubcategories = await this.db.Subcategories.AnyAsync(s => s.CategoryId == categoryId);
            if (hasSubcategories)
                throw new InvalidOperationException("Нельзя удалить категорию, содержащую подкатегории. Сначала удалите подкатегории.");

            this.db.Categories.Remove(category);
            await this.db.SaveChangesAsync();
        }

        public async Task<Category?> GetCategoriesByIdAsync(int categoryId)
        {
            return await this.db.Categories.FindAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> GetCategoriesByNameAsync(string name)
        {
            return await this.db.Categories.Where(c => string.IsNullOrWhiteSpace(name) || 
                                                  c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            if (await this.db.Categories.AnyAsync(c =>
            c.Name.ToLower() == category.Name.ToLower() && c.Id != category.Id))
                throw new InvalidOperationException("Категория с таким именем уже существует");

            var existing = await this.db.Categories.FindAsync(category.Id);
            if (existing == null)
                throw new InvalidOperationException($"Категория с Id={category.Id} не найдена");

            existing.Name = category.Name;


            this.db.Categories.Update(existing);
            await this.db.SaveChangesAsync();
        }
    }
}
