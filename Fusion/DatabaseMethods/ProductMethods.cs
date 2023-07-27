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
    public class ProductMethods<T> : IProductMethods<T> where T : Product
    {
        private readonly IdentityDBContext _context;
        public ProductMethods(IdentityDBContext context)
        {
            _context = context;
        }

        public async Task Create(AddProductViewModel viewModel)
        {
            T product = (T)new Product() { Name = viewModel.Name, Description = viewModel.Description, Price = viewModel.Price, Url = viewModel.Url };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            T product = (T)await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> Get(Guid id)
        {
            List<Product> products = await _context.Products.Include(c => c.ProductCategories).ToListAsync();
            Product product = products.Where(s => s.Id == id).FirstOrDefault();
            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            List<Product> products = await _context.Products.Include(c => c.ProductCategories).ToListAsync();
            return products;
        }

        public async Task Update(T updatingproduct)
        {
            Product product = await Get(updatingproduct.Id);
            product.Name = updatingproduct.Name;
            product.Price = updatingproduct.Price;
            product.Description = updatingproduct.Description;
            product.Url = updatingproduct.Url;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductCategories(T updatingProduct)
        {
            Product category = await Get(updatingProduct.Id);
            category.ProductCategories = updatingProduct.ProductCategories;
            await _context.SaveChangesAsync();
        }
    }
}
