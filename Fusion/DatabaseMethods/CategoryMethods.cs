using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fusion.Models;
using Fusion.Interfaces;
using Fusion.DataBase;
using Fusion.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Fusion.DatabaseMethods
{
    public class CategoryMethods<T> : ICategoryMethods<T> where T : Category
    {
        private readonly IdentityDBContext _context;
        public CategoryMethods(IdentityDBContext context)
        {
            _context = context;
        }
        public async Task Delete(Guid id)
        {
            T category = (T)await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task Create(AddCategoryViewModel viewModel)
        {
            T category = (T)new Category() { Name = viewModel.Name, Fullname =viewModel.Fullname };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> Get(Guid id)
        {
            var categories = await _context.Categories.Include(c => c.ProductCategories).ToListAsync();
            Category category = categories.Where(ca => ca.Id == id).FirstOrDefault();
            return category;
        }

        public async Task<List<Category>> GetAll()
        {
            List<Category> categories = await _context.Categories.Include(c => c.ProductCategories).ToListAsync();
            return categories;
        }
        
        //Made for all NONrelationship properties
        public async Task Update(T updatingCategory)
        {
            Category category = await Get(updatingCategory.Id);
            category.Name = updatingCategory.Name;
            category.Fullname = updatingCategory.Fullname;
            await _context.SaveChangesAsync();
        }
        //Made for (one)relationship property
        //Make for every relationship - easier to complain
        public async Task UpdateProductCategories(T updatingCategory)
        {
            Category category = await Get(updatingCategory.Id);
            category.ProductCategories = updatingCategory.ProductCategories;
            await _context.SaveChangesAsync();
        }
    }
}
