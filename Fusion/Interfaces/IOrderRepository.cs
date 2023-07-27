using Fusion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.Interfaces
{
    public interface IOrderRepository<T> where T : class
    {
        public Task Create(Guid productId, string email);
        public Task Update(T updatingOrder);
        public Task ConfirmOrder(Guid OrderId);
        public Task<bool> Delete(Guid orderId);
        public Task DeleteObjFromOrder(Guid productId);
        public Task Clear(Guid id);
        public Task<Order> Get(Guid id);
        public List<Order> GetAll();
    }
}
