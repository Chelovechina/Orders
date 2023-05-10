using Orders.Domain.DTO;

namespace Orders.BLL.Interfaces
{
    public interface IItemService
    {
        public Task<ItemDto> Create(ItemDto entity);
        public Task<ItemDto> Delete(int id);
        public Task<ItemDto> Update(ItemDto entity);
        public Task<IEnumerable<ItemDto>> Get();
        public Task<ItemDto> Get(int id);
    }
}
