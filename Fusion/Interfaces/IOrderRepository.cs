using Fusion.Models;
using Fusion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.Interfaces
{
    public interface IOrderRepository<T> where T : class
    {
        public Task Create(Guid productId, string email);
        public Task Add(Guid orderId, Guid productId);
        public Task Update(T updatingOrder);
        public Task ConfirmOrder(Guid OrderId, string Email);
        public Task<bool> Delete(Guid orderId);
        public Task DeleteObjFromOrder(Guid productId);
        public Task Clear(Guid id);
        public Task<Order> Get(Guid id);
        public List<Order> GetAll();
        public Task ChangeCount(CounterViewModel viewModel);
    }
}
