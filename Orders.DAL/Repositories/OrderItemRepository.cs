using Microsoft.EntityFrameworkCore;
using Orders.DAL.Data;
using Orders.DAL.Interfaces;
using Orders.Domain.Entities;

namespace Orders.DAL.Repositories
{
    public class OrderItemRepository : IRepository<OrderItem>
    {
        private readonly AppDBContext _dbContext;

        public OrderItemRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderItem> Create(OrderItem entity)
        {
            try
            {
                await _dbContext.orderItem.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<OrderItem> Delete(int id)
        {
            try
            {
                var orderItem = await _dbContext.orderItem.FindAsync(id);
                _dbContext.orderItem.Remove(orderItem);
                await _dbContext.SaveChangesAsync();
                return orderItem;
            }
            catch(Exception ex) 
            { 
                throw ex; 
            }
        }

        public async Task<IEnumerable<OrderItem>> Get()
        {
            try
            {
                var orderItems = await _dbContext.orderItem.ToListAsync();
                return orderItems;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderItem> Get(int id)
        {
            try
            {
                var orderItem = await _dbContext.orderItem.FindAsync(id);
                return orderItem;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderItem> Update(OrderItem entity)
        {
            try
            {
                var orderItem = _dbContext.orderItem.Entry(entity);
                orderItem.State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
