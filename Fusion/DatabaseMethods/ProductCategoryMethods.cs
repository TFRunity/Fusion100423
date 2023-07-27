using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fusion.Models;
using Fusion.Interfaces;
using Fusion.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Fusion.DatabaseMethods
{
    public class ProductCategoryMethods<T> : IProductCategoryMethods<T> where T : ProductCategory
    {
        private readonly IdentityDBContext _context;
        private readonly IProductMethods<Product> _productMethods;
        private readonly ICategoryMethods<Category> _categoryMethods;
        public ProductCategoryMethods(IdentityDBContext context, IProductMethods<Product> productMethods, ICategoryMethods<Category> categoryMethods)
        {
            _context = context;
            _productMethods = productMethods;
            _categoryMethods = categoryMethods;
        }
        //Create 
        public async Task CreateRelationship(Guid productId, Guid categoryId)
        {
            Product product = await _productMethods.Get(productId);
            Category category = await _categoryMethods.Get(categoryId);
            ProductCategory productCategory = new ProductCategory()
            {
                CategoryId = categoryId,
                ProductId = productId,
                Category = category,
                Product = product
            };
            product.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();
        }
        //Delete all
        public async Task DeleteRelationship(Guid productId, Guid categoryId)
        {
            Product product = await _productMethods.Get(productId);
            Category category = await _categoryMethods.Get(categoryId);
            ProductCategory productCategoryToRemove = await _context.ProductCategories.Where(x => x.CategoryId == categoryId).FirstOrDefaultAsync();
            product.ProductCategories.Remove(productCategoryToRemove);
            await _context.SaveChangesAsync();
        }
        //Update for Product
        public async Task UpdateRelationshipProduct(Guid productId, List<ProductCategory> productCategoriesToUpdate)
        {
            //Change Product relationships
            Product product = await _productMethods.Get(productId);
            foreach (ProductCategory productCategory in product.ProductCategories)
            {
                product.ProductCategories.Remove(productCategory);
            }
            product.ProductCategories = productCategoriesToUpdate;
            await _productMethods.UpdateProductCategories(product);
        }
        //Update for Category (Use right after UpdateRelationshipProduct)
        public async Task UpdateRelationshipCategory(List<Guid> categoriesIdToUpdate, List<Guid> categoriesIdToDelete, Guid productId)
        {
            //Delete Relationships 
            foreach(Guid categoryId in categoriesIdToDelete)
            {
                await DeleteRelationship(productId, categoryId);
            }

            //Change Categories to update
            foreach (Guid categoryId in categoriesIdToUpdate)
            {
                await CreateRelationship(productId, categoryId);
            }
        }
    }
}
