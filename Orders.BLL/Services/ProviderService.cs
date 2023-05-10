using Orders.BLL.Interfaces;
using Orders.DAL.Repositories;
using Orders.Domain.DTO;
using Orders.Domain.Entities;

namespace Orders.BLL.Services
{
    public class ProviderService : IProviderService
    {
        private readonly ProviderRepository _repository;

        public ProviderService(ProviderRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProviderDto> Create(ProviderDto entity)
        {
            try
            {
                var provider = new Provider
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Orders = (from o in entity.Orders
                              select
                              new Order
                              {
                                  Date = o.Date,
                                  Id = o.Id,
                                  Description = o.Description,
                                  Number = o.Number,
                                  ProviderId = o.ProviderId
                              }).ToList(),
                };
                var result = await _repository.Create(provider);
                return new ProviderDto
                {
                    Id = result.Id,
                    Name = result.Name,
                    Orders = (from o in result.Orders
                              select
                              new OrderDto
                              {
                                  Id = o.Id,
                                  Date = o.Date,
                                  Description = o.Description,
                                  Number = o.Number,
                                  ProviderId = o.ProviderId,
                              }).ToList(),
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProviderDto> Delete(int id)
        {
            try
            {
                var result = await _repository.Delete(id);
                return new ProviderDto
                {
                    Id = result.Id,
                    Name = result.Name,
                    Orders = (from o in result.Orders
                              select
                              new OrderDto
                              {
                                  Id = o.Id,
                                  Date = o.Date,
                                  Description = o.Description,
                                  Number = o.Number,
                                  ProviderId = o.ProviderId,
                              }).ToList(),
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ProviderDto>> Get()
        {
            try
            {
                var results = await _repository.Get();
                return from result in results
                       select
                       new ProviderDto
                       {
                           Id = result.Id,
                           Name = result.Name,
                           Orders = (from o in result.Orders
                                     select
                                     new OrderDto
                                     {
                                         Id = o.Id,
                                         Date = o.Date,
                                         Description = o.Description,
                                         Number = o.Number,
                                         ProviderId = o.ProviderId,
                                     }).ToList(),
                       };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProviderDto> Get(int id)
        {
            try
            {
                var result = await _repository.Get(id);
                return new ProviderDto
                {
                    Id = result.Id,
                    Name = result.Name,
                    Orders = (from o in result.Orders
                              select
                              new OrderDto
                              {
                                  Id = o.Id,
                                  Date = o.Date,
                                  Description = o.Description,
                                  Number = o.Number,
                                  ProviderId = o.ProviderId,
                              }).ToList(),
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProviderDto> Update(ProviderDto entity)
        {
            try
            {
                var provider = new Provider
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Orders = (from o in entity.Orders
                              select
                              new Order
                              {
                                  Date = o.Date,
                                  Id = o.Id,
                                  Description = o.Description,
                                  Number = o.Number,
                                  ProviderId = o.ProviderId
                              }).ToList(),
                };
                var result = await _repository.Update(provider);
                return new ProviderDto
                {
                    Id = result.Id,
                    Name = result.Name,
                    Orders = (from o in result.Orders
                              select
                              new OrderDto
                              {
                                  Id = o.Id,
                                  Date = o.Date,
                                  Description = o.Description,
                                  Number = o.Number,
                                  ProviderId = o.ProviderId,
                              }).ToList(),
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
