using Orders.BLL.Interfaces;
using Orders.DAL.Repositories;
using Orders.Domain.DTO;
using Orders.Domain.Entities;

namespace Orders.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _repository;

        public OrderService(OrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<OrderDto> Create(OrderDto entity)
        {
            try
            {
                var order = new Order
                {
                    Id = entity.Id,
                    Date = entity.Date,
                    Description = entity.Description,
                    Number = entity.Number,
                    ProviderId = entity.ProviderId
                };
                var result = await _repository.Create(order);
                return new OrderDto
                {
                    Id = result.Id,
                    Date = result.Date,
                    Description = result.Description,
                    Number = result.Number,
                    ProviderId = result.ProviderId
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderDto> Delete(int id)
        {
            try
            {
                var result = await _repository.Delete(id);
                return new OrderDto
                {
                    Id = result.Id,
                    Date = result.Date,
                    Description = result.Description,
                    Number = result.Number,
                    ProviderId = result.ProviderId
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<OrderDto>> Get()
        {
            try
            {
                var reluts = await _repository.Get();
                return from result in reluts
                       select
                       new OrderDto
                       {
                           Id = result.Id,
                           Date = result.Date,
                           Description = result.Description,
                           Number = result.Number,
                           ProviderId = result.ProviderId
                       };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderDto> Get(int id)
        {
            try
            {
                var result = await _repository.Get(id);
                return new OrderDto
                {
                    Id = result.Id,
                    Date = result.Date,
                    Description = result.Description,
                    Number = result.Number,
                    ProviderId = result.ProviderId
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderDto> Update(OrderDto entity)
        {
            try
            {
                var order = new Order
                {
                    Id = entity.Id,
                    Date = entity.Date,
                    Description = entity.Description,
                    Number = entity.Number,
                    ProviderId = entity.ProviderId
                };
                var result = await _repository.Update(order);
                return new OrderDto
                {
                    Id = result.Id,
                    Date = result.Date,
                    Description = result.Description,
                    Number = result.Number,
                    ProviderId = result.ProviderId
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
