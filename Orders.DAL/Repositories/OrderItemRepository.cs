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
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<OrderItem> Delete(int id)
        {
            try
            {
                var order = await _dbContext.orderItem.FindAsync(id);
                _dbContext.orderItem.Remove(order);
                await _dbContext.SaveChangesAsync();
                return order;
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }

        public async Task<IEnumerable<OrderItem>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<OrderItem> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderItem> Update(OrderItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
