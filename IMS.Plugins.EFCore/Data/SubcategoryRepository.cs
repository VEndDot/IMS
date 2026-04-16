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

        public async Task<IEnumerable<Subcategory>> GetSubcategoryByNameAsync(string name)
        {
            var query = this.db.Subcategories.Include(s => s.Category).AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(s => s.Name.ToLower().Contains(name.ToLower()) || s.Category.Name.ToLower().Contains(name.ToLower()));
            }

            return await query.ToListAsync();
        }
    }
}
