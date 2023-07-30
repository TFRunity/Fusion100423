using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fusion.Interfaces;
using Fusion.Models;
using Fusion.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Fusion.ViewModels;

namespace Fusion.DatabaseMethods
{
    public class OrderMethods<T> : IOrderRepository<T> where T : Order
    {
        private readonly IdentityDBContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IProductMethods<Product> _productMethods;
        public OrderMethods(IdentityDBContext context, UserManager<User> userManager, IProductMethods<Product> productMethods)
        {
            _context = context;
            _userManager = userManager;
            _productMethods = productMethods;
        }
        
        public async Task Create(Guid productId, string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            Product product = await _productMethods.Get(productId);
            if (user.CurrentOrderId == Guid.Empty)
            {
                Order order = new Order();
                ProductId id = new ProductId() { IdFromProduct = productId, PriceFromProduct = product.Price};
                await _context.ProductIds.AddAsync(id);
                order.ProductIds.Add(id);
                order.TotalPrice += id.PriceFromProduct * id.CurrentCount;
                await _context.Orders.AddAsync(order);
                user.CurrentOrderId = order.Id;
                user.Orders.Add(order);
                await _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                Order order = await _context.Orders.FindAsync(user.CurrentOrderId);
                ProductId id = new ProductId() { IdFromProduct = productId, PriceFromProduct = product.Price };
                await _context.ProductIds.AddAsync(id);
                order.ProductIds.Add(id);
                order.TotalPrice += id.PriceFromProduct * id.CurrentCount;
                await _context.SaveChangesAsync();
            }
        }
        //Доделать некоторые действия
        public async Task<bool> Delete(Guid orderId)
        {
            List<ProductId> productIdsToDelete = await _context.ProductIds.Where(X => X.OrderId == orderId).ToListAsync();
            _context.RemoveRange(productIdsToDelete);
            Order order = await _context.Orders.FindAsync(orderId);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<Order> Get(Guid orderId)
        {
            List<Order> orders = await _context.Orders.Include(x => x.ProductIds).Include(y => y.User).ToListAsync();
            Order order = orders.Where(y => y.Id == orderId).FirstOrDefault();
            return order;
        }

        public List<Order> GetAll()
        {
            List<Order> orders = _context.Orders.Include(x => x.ProductIds).Include(y => y.User).ToList();
            return orders;
        }

        public async Task Update(T updatingOrder)
        {
            Order order = await Get(updatingOrder.Id);
            order.Done = updatingOrder.Done;
            await _context.SaveChangesAsync();
        }

        public async Task ConfirmOrder(Guid orderId, string email)
        {
            Order order = await Get(orderId);
            order.Paid = true;
            User user = await _userManager.FindByEmailAsync(email);
            user.CurrentOrderId = Guid.Empty;
            await _context.SaveChangesAsync();
        }

        //бесполезная хрень
        public async Task Add(Guid orderId, Guid productId)
        {
            Order order = await Get(orderId);
            ProductId _productId = new ProductId() { IdFromProduct = productId };
            await _context.ProductIds.AddAsync(_productId);
            order.ProductIds.Add(_productId);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteObjFromOrder(Guid id)
        {
            ProductId productId = await _context.ProductIds.FindAsync(id);
            Order order = productId.Order;
            order.TotalPrice -= productId.PriceFromProduct * productId.CurrentCount;
            _context.ProductIds.Remove(productId);
            await _context.SaveChangesAsync();
        }
        public async Task Clear(Guid orderId)
        {
            Order order = await Get(orderId);
            _context.ProductIds.RemoveRange(order.ProductIds);
            order.TotalPrice = 0;
            await _context.SaveChangesAsync();
        }
        //Special method for ProductId
        public async Task ChangeCount(CounterViewModel viewModel)
        {
            ProductId productId = await _context.ProductIds.FindAsync(viewModel.ProductId);
            Order order = productId.Order;
            order.TotalPrice -= productId.PriceFromProduct * viewModel.PreviousCount;
            order.TotalPrice += productId.PriceFromProduct * viewModel.CurrentCount;
            productId.CurrentCount = viewModel.CurrentCount;
            productId.PreviousCount = viewModel.CurrentCount;
            await _context.SaveChangesAsync();
        }
    }
}
