using Orders.Domain.DTO;

namespace Orders.BLL.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderDto> Create(OrderDto entity);
        public Task<OrderDto> Delete(int id);
        public Task<OrderDto> Update(OrderDto entity);
        public Task<IEnumerable<OrderDto>> Get();
        public Task<OrderDto> Get(int id);
    }
}
