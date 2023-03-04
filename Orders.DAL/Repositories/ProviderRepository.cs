using Microsoft.EntityFrameworkCore;
using Orders.DAL.Data;
using Orders.DAL.Interfaces;
using Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.DAL.Repositories
{
    public class ProviderRepository : IRepository<Provider>
    {
        private readonly AppDBContext _dbContext;

        public ProviderRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Provider> Create(Provider entity)
        {
            try 
            {
                await _dbContext.provider.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            } 
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<Provider> Delete(int id)
        {
            try
            {
                var provider = await _dbContext.provider.FindAsync(id);
                _dbContext.provider.Remove(provider);
                await _dbContext.SaveChangesAsync();
                return provider;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Provider>> Get()
        {
            try
            {
                var providers = await _dbContext.provider.ToListAsync();
                return providers;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Provider> Get(int id)
        {
            try
            {
                var provider = await _dbContext.provider.FindAsync(id);
                return provider;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Provider> Update(Provider entity)
        {
            try
            {
                var provider = _dbContext.provider.Entry(entity);
                provider.State = EntityState.Modified;
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
