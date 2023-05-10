using Orders.Domain.DTO;

namespace Orders.BLL.Interfaces
{
    public interface IOrderItemService
    {
        public Task<OrderItemDto> Create(OrderItemDto entity);
        public Task<OrderItemDto> Delete(int id);
        public Task<OrderItemDto> Update(OrderItemDto entity);
        public Task<IEnumerable<OrderItemDto>> Get();
        public Task<OrderItemDto> Get(int id);
    }
}
