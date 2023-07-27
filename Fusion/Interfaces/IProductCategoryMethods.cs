using Fusion.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fusion.Interfaces
{
    public interface IProductCategoryMethods<T> where T : class
    {
        public Task CreateRelationship(Guid productId, Guid categoryId);
        public Task DeleteRelationship(Guid productId, Guid categoryId);
        public Task UpdateRelationshipProduct(Guid productId, List<ProductCategory> productCategoriesToUpdate);
        public Task UpdateRelationshipCategory(List<Guid> categoriesIdToUpdate, List<Guid> categoriesIdToDelete, Guid productId);
    }
}
