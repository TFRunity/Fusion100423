using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fusion.Models;
using Fusion.ViewModels;

namespace Fusion.Interfaces
{
    public interface ICategoryMethods<T> where T : class
    {
        public Task<Category> Get(Guid id);
        public Task Create(AddCategoryViewModel viewModel);
        public Task Delete(Guid id);
        public Task<List<Category>> GetAll();
        public Task Update(T updatingcategory);
        public Task UpdateProductCategories(T updatingCategory);
    }
}
