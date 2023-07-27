using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fusion.ViewModels;
using Fusion.Models;

namespace Fusion.Interfaces
{
    public interface IProductMethods<T> where T : class
    {
        public Task Create(AddProductViewModel viewModel);
        public Task<Product> Get(Guid id);
        public Task Delete(Guid id);
        public Task<List<Product>> GetAll();
        public Task Update(T product);
        public Task UpdateProductCategories(T updatingProduct);
    }
}
