using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fusion.Interfaces;
using Fusion.Models;
using Fusion.DataBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fusion.DatabaseMethods
{
    public class OrderMethods<T> : IOrderRepository<T> where T : Order
    {
        private readonly IdentityDBContext _context;
        private readonly UserManager<User> _userManager;
        public OrderMethods(IdentityDBContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        public async Task Create(Guid productId, string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            if (user.CurrentOrderId == Guid.Empty)
            {
                Order order = new Order();
                ProductId id = new ProductId() { IdFromProduct = productId };
                order.ProductIds.Add(id);
                await _context.SaveChangesAsync();
                user.CurrentOrderId = order.Id;
                await _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                Order order = await _context.Orders.FindAsync(user.CurrentOrderId);
                ProductId id = new ProductId() { IdFromProduct = productId };
                order.ProductIds.Add(id);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> Delete(Guid orderId)
        {
            Order order = await _context.Orders.FindAsync(orderId);
            if (order.Paid == true)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
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
            order.ProductIds = updatingOrder.ProductIds;
            order.Done = updatingOrder.Done;
            order.TotalPrice = updatingOrder.TotalPrice;
            await _context.SaveChangesAsync();
        }

        public async Task ConfirmOrder(Guid OrderId)
        {
            Order order = await Get(OrderId);
            order.Paid = true;
            await _context.SaveChangesAsync();
        }

        public async Task Add(Guid OrderId, Guid ProductId)
        {
            Order order = await Get(OrderId);
            ProductId productId = new ProductId() { IdFromProduct = ProductId };
            order.ProductIds.Add(productId);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteObjFromOrder(Guid id)
        {
            ProductId productId = await _context.ProductIds.FindAsync(id);
            _context.ProductIds.Remove(productId);
            await _context.SaveChangesAsync();
        }
        public async Task Clear(Guid id)
        {
            Order order = await Get(id);
            order.ProductIds.Clear();
            await _context.SaveChangesAsync();
        }
        //Special method for ProductId
        public async Task ChangeCount(Guid ProductId, int Count)
        {
            ProductId productId = await _context.ProductIds.FindAsync(ProductId);
            productId.Count = Count;
            await _context.SaveChangesAsync();
        }
    }
}
