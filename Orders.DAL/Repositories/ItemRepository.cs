using Microsoft.EntityFrameworkCore;
using Orders.DAL.Data;
using Orders.DAL.Interfaces;
using Orders.Domain.Entities;

namespace Orders.DAL.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly AppDBContext _dbContext;

        public ItemRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Item> Create(Item entity)
        {
            try
            {
                await _dbContext.item.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        public async Task<IEnumerable<Item>> Get()
        {
            try
            {
                var items = await _dbContext.item.ToListAsync();
                return items;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Item> Get(int id)
        {
            try
            {
                var item = await _dbContext.item.FindAsync(id);
                return item;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Item> Update(Item entity)
        {
            try
            {
                var item = _dbContext.item.Entry(entity);
                item.State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<Item> Delete(int id)
        {
            try
            {
                var item = await _dbContext.item.FindAsync(id);
                _dbContext.item.Remove(item);
                await _dbContext.SaveChangesAsync();
                return item;
            } 
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
