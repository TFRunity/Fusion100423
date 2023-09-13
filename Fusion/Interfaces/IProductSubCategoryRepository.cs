using Fusion.Models;
using Fusion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Fusion.Interfaces
{
    public interface IProductSubCategoryRepository<T> where T : class
    {
        public Task Create(SubCategoryViewModel viewModel);
        public Task Delete(Guid subCategoryId);
        public Task<ProductSubCategory> Get(Guid subCategoryId);
        public Task<OneProductSubCategory> GetCurrent(Guid subCategoryId, string _case);
        public Task Update(SubCategoryViewModel subCategoryViewModel);
        public Task<string> GetCase(Guid subCategoryId);
    }
}
