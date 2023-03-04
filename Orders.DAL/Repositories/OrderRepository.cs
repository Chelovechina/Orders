using Microsoft.EntityFrameworkCore;
using Orders.DAL.Data;
using Orders.DAL.Interfaces;
using Orders.Domain.Entities;

namespace Orders.DAL.Repositories
{
    internal class OrderRepository : IRepository<Order>
    {
        private readonly AppDBContext _dbContext;
        
        public OrderRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> Create(Order entity)
        {
            try
            {
                await _dbContext.order.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> Delete(int id)
        {
            try
            {
                var order = await _dbContext.order.FindAsync(id);
                _dbContext.order.Remove(order);
                await _dbContext.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Order>> Get()
        {
            try
            {
                var orders = await _dbContext.order.ToListAsync();
                return orders;
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }

        public async Task<Order> Get(int id)
        {
            try
            {
                var order = await _dbContext.order.FindAsync(id);
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> Update(Order entity)
        {
            try
            {
                var order = _dbContext.order.Entry(entity);
                order.State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
