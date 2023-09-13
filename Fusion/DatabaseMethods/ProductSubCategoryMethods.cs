using Fusion.DataBase;
using Fusion.Interfaces;
using Fusion.Models;
using Fusion.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.DatabaseMethods
{
    public class ProductSubCategoryMethods<T> : IProductSubCategoryRepository<T> where T : ProductSubCategory
    {
        private readonly IdentityDBContext _context;
        private readonly IProductMethods<Product> _productMethods;
        public ProductSubCategoryMethods(IdentityDBContext context, IProductMethods<Product> productMethods)
        {
            _context = context;
            _productMethods = productMethods;
        }
        public async Task Create(SubCategoryViewModel viewModel)
        {
            if (viewModel.ProductSubCategoryId == Guid.Empty || viewModel.ProductSubCategoryId == null)
            {
                ProductSubCategory productSubCategory = new ProductSubCategory();
                productSubCategory.FirstFeature = viewModel.Feature;
                productSubCategory.FirstPrice = viewModel.Price;
                productSubCategory.FirstUrl = viewModel.Url;
                await _context.ProductSubCategories.AddAsync(productSubCategory);
                Product product = await _productMethods.Get(viewModel.ProductId);
                product.ProductSubCategories = productSubCategory;
                await _context.SaveChangesAsync();
            }
            else
            {
                ProductSubCategory productSubCategory = await Get(viewModel.ProductSubCategoryId);
                switch (viewModel._Case)
                {
                    case "Second":
                        productSubCategory.SecondFeature = viewModel.Feature;
                        productSubCategory.SecondPrice = viewModel.Price;
                        productSubCategory.SecondUrl = viewModel.Url;
                        await _context.SaveChangesAsync();
                        break;
                    case "Third":
                        productSubCategory.ThirdFeature = viewModel.Feature;
                        productSubCategory.ThirdPrice = viewModel.Price;
                        productSubCategory.ThirdUrl = viewModel.Url;
                        await _context.SaveChangesAsync();
                        break;
                }
            }

        }

        public async Task Delete(Guid subCategoryId)
        {
            ProductSubCategory productSubCategory = await Get(subCategoryId);
            _context.ProductSubCategories.Remove(productSubCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductSubCategory> Get(Guid subCategoryId)
        {
            ProductSubCategory productSubCategory = await _context.ProductSubCategories.FindAsync(subCategoryId);
            return productSubCategory;
        }

        public async Task Update(SubCategoryViewModel subCategoryViewModel)
        {
            ProductSubCategory productSubCategory = await Get(subCategoryViewModel.ProductSubCategoryId);
            switch (subCategoryViewModel._Case)
            {
                case "First":
                    productSubCategory.FirstFeature = subCategoryViewModel.Feature;
                    productSubCategory.FirstPrice = subCategoryViewModel.Price;
                    productSubCategory.FirstUrl = subCategoryViewModel.Url;
                    await _context.SaveChangesAsync();
                    break;
                case "Second":
                    productSubCategory.SecondFeature = subCategoryViewModel.Feature;
                    productSubCategory.SecondPrice = subCategoryViewModel.Price;
                    productSubCategory.SecondUrl = subCategoryViewModel.Url;
                    await _context.SaveChangesAsync();
                    break;
                case "Third":
                    productSubCategory.ThirdFeature = subCategoryViewModel.Feature;
                    productSubCategory.ThirdPrice = subCategoryViewModel.Price;
                    productSubCategory.ThirdUrl = subCategoryViewModel.Url;
                    await _context.SaveChangesAsync();
                    break;
            }
        }
        public async Task<OneProductSubCategory> GetCurrent(Guid subCategoryId, string _case)
        {
            ProductSubCategory productSubCategory = await Get(subCategoryId);
            OneProductSubCategory oneSubCategory = new OneProductSubCategory();
            switch (_case)
            {
                case "First":
                    oneSubCategory.Feature = productSubCategory.FirstFeature;
                    oneSubCategory.Price = productSubCategory.FirstPrice;
                    oneSubCategory.Url = productSubCategory.FirstUrl;
                    break;
                case "Second":
                    oneSubCategory.Feature = productSubCategory.SecondFeature;
                    oneSubCategory.Price = productSubCategory.SecondPrice;
                    oneSubCategory.Url = productSubCategory.SecondUrl;
                    break;
                case "Third":
                    oneSubCategory.Feature = productSubCategory.ThirdFeature;
                    oneSubCategory.Price = productSubCategory.ThirdPrice;
                    oneSubCategory.Url = productSubCategory.ThirdUrl;
                    break;
            }
            return oneSubCategory;
        }
        public async Task<string> GetCase(Guid subCategoryId)
        {
            ProductSubCategory subCategory = await Get(subCategoryId);
            if (subCategory.ThirdFeature != null && subCategory.ThirdFeature != "")
                return "Third";
            if (subCategory.SecondFeature != null && subCategory.SecondFeature != "")
                return "Second";
            if (subCategory.FirstFeature != null && subCategory.FirstFeature != "")
                return "First";
            return "None";
        }
    }
}
