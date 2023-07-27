using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fusion.Interfaces;
using Fusion.Models;
using Fusion.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Fusion.Controllers
{
    [Authorize(Policy = "Manager")]
    public class ProductModeratorController : Controller
    {
        private readonly IProductMethods<Product> _productMethods;
        private readonly ICategoryMethods<Category> _categoryMethods;
        private readonly IProductCategoryMethods<ProductCategory> _relationshipsMethods;
        public ProductModeratorController(IProductMethods<Product> productMethods, ICategoryMethods<Category> categoryMethods, IProductCategoryMethods<ProductCategory> productCategoryMethods)
        {
            _productMethods = productMethods;
            _categoryMethods = categoryMethods;
            _relationshipsMethods = productCategoryMethods;
        }


        //
        // Product interaction
        //


        //List of products with category relationships
        public async Task<IActionResult> ListProduct()
        {
            List<Product> products = await _productMethods.GetAll();
            if (products == null)
            {
                return View();
            }
            return View(products);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            AddProductViewModel viewModel = new AddProductViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(AddProductViewModel productViewModel)
        {
            await _productMethods.Create(productViewModel);
            return RedirectToAction(nameof(ListProduct));
        }

        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            Product productToDelete = await _productMethods.Get(id);
            if (productToDelete.ProductCategories != null)
            {
                foreach (ProductCategory relationship in productToDelete.ProductCategories)
                {
                    await _relationshipsMethods.DeleteRelationship(id, relationship.CategoryId);
                }
            }
            await _productMethods.Delete(id);
            return RedirectToAction(nameof(ListProduct));
        }
        

        //Without relationships
        [HttpGet]
        public async Task<IActionResult> EditProduct(Guid id)
        {
            Product product = await _productMethods.Get(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            await _productMethods.Update(product);
            return RedirectToAction(nameof(ListProduct));
        }


        //
        // Category interaction
        //


        //List of all categories
        public async Task<IActionResult> ListCategory()
        {
            List<Category> categories = await _categoryMethods.GetAll();
            if (categories == null)
            {
                return View();
            }
            return View(categories);
        }
        
        [HttpGet]
        public IActionResult CreateCategory()
        {
            AddCategoryViewModel viewModel = new AddCategoryViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(AddCategoryViewModel viewModel)
        {
            await _categoryMethods.Create(viewModel);
            return RedirectToAction(nameof(ListCategory));
        }

        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            Category categoryToDelete = await _categoryMethods.Get(id);
            if (categoryToDelete.ProductCategories != null)
            {
                foreach (ProductCategory relationship in categoryToDelete.ProductCategories)
                {
                    await _relationshipsMethods.DeleteRelationship(relationship.ProductId, id);
                }
            }
            await _categoryMethods.Delete(id);
            return RedirectToAction(nameof(ListCategory));
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(Guid id)
        {
            Category category = await _categoryMethods.Get(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Category category)
        {
            await _categoryMethods.Update(category);
            return RedirectToAction(nameof(ListCategory));
        }


        //
        // Relationship interaction
        //

        [HttpGet]
        public async Task<IActionResult> ChangeProductCategories(Guid productId)
        {
            Product product = await _productMethods.Get(productId);
            ChangeRelationshipsProductViewModel viewModel = new ChangeRelationshipsProductViewModel()
            {
                CurrentRelationships = product.ProductCategories,
                ProductId = product.Id
            };
            return View(viewModel);
        }
        //Комплексный метод, меняет всё что нужно и не нужно
        [HttpPost]
        public async Task<IActionResult> ChangeProductCategories(ChangeRelationshipsProductViewModel viewModel)
        {
            List<ProductCategory> relationshipsToUpdate = new List<ProductCategory>();
            foreach (Category category in viewModel.RelationshipsToUpdate)
            {
                ProductCategory productCategory = new ProductCategory()
                {
                    ProductId = viewModel.ProductId,
                    CategoryId = category.Id
                };
                relationshipsToUpdate.Add(productCategory);
            }
            await _relationshipsMethods.UpdateRelationshipProduct(viewModel.ProductId, relationshipsToUpdate);
            //Categories to update
            List<Guid> idToUpdate = new List<Guid>();
            foreach (Category category in viewModel.RelationshipsToUpdate)
            {
                Guid id = category.Id;
                idToUpdate.Add(id);
            }
            //Categories to delete
            List<Guid> idToDelete = new List<Guid>();
            foreach (ProductCategory productCategory in viewModel.CurrentRelationships)
            {
                Guid id = productCategory.CategoryId;
                idToDelete.Add(id);
            }
            //Call of category method
            await _relationshipsMethods.UpdateRelationshipCategory(idToUpdate, idToDelete, viewModel.ProductId);
            return RedirectToAction(nameof(ListCategory));
        }
        //Простые Action для смены единичной связи (БЕЗ ПРОКЛЯТОЙ КНОПКИ)
        [HttpGet]
        public async Task<IActionResult> CreateProductRelationship(Guid productId)
        {
            Product product = await _productMethods.Get(productId);
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProductRelationships(Guid productId, Guid categoryId)
        {
            await _relationshipsMethods.CreateRelationship(productId, categoryId);
            return RedirectToAction(nameof(ListProduct));
        }
        public async Task<IActionResult> DeleteProductRelationship(Guid productId, Guid categoryId)
        {
            await _relationshipsMethods.DeleteRelationship(productId,categoryId);
            return RedirectToAction(nameof(ListProduct));
        }
        //Написать методы создания связи и удаления связи ( action )
    }
}
