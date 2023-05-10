using Orders.BLL.Interfaces;
using Orders.DAL.Repositories;
using Orders.Domain.DTO;
using Orders.Domain.Entities;

namespace Orders.BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemRepository _repository;

        public ItemService(ItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<ItemDto> Create(ItemDto entity)
        {
            try
            {
                var item = new Item
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Quantity = entity.Quantity,
                    Unit = entity.Unit,
                    Price = entity.Price,
                    Orders = (from o in entity.Orders
                              select
                              new Order
                              { 
                                  Id = o.Id,
                                  Date = o.Date,
                                  Description = o.Description,
                                  Number = o.Number,
                                  ProviderId = o.ProviderId,
                              }).ToList(),
                };
                var result = await _repository.Create(item);
                return new ItemDto
                {
                    Id = result.Id,
                    Name = result.Name,
                    Quantity = result.Quantity,
                    Unit = result.Unit,
                    Price = result.Price,
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

        public async Task<ItemDto> Delete(int id)
        {
            try 
            {
                var result = await _repository.Delete(id);
                return new ItemDto
                {
                    Id = result.Id,
                    Name = result.Name,
                    Quantity = result.Quantity,
                    Unit = result.Unit,
                    Price = result.Price,
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

        public async Task<IEnumerable<ItemDto>> Get()
        {
            var results = await _repository.Get();
            return from result in results
                   select new ItemDto
                   {
                       Id = result.Id,
                       Name = result.Name,
                       Quantity = result.Quantity,
                       Unit = result.Unit,
                       Price = result.Price,
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

        public async Task<ItemDto> Get(int id)
        {
            var result = await _repository.Get(id);
            return new ItemDto
            {
                Id = result.Id,
                Name = result.Name,
                Quantity = result.Quantity,
                Unit = result.Unit,
                Price = result.Price,
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

        public async Task<ItemDto> Update(ItemDto entity)
        {
            var item = new Item
            {
                Id = entity.Id,
                Name = entity.Name,
                Quantity = entity.Quantity,
                Unit = entity.Unit,
                Price = entity.Price,
                Orders = (from o in entity.Orders
                          select
                          new Order
                          {
                              Id = o.Id,
                              Date = o.Date,
                              Description = o.Description,
                              Number = o.Number,
                              ProviderId = o.ProviderId,
                          }).ToList(),
            };
            var result = await _repository.Update(item);
            return new ItemDto
            {
                Id = result.Id,
                Name = result.Name,
                Quantity = result.Quantity,
                Unit = result.Unit,
                Price = result.Price,
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
    }
}
