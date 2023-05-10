using Orders.Domain.DTO;

namespace Orders.BLL.Interfaces
{
    public interface IProviderService
    {
        public Task<ProviderDto> Create(ProviderDto entity);
        public Task<ProviderDto> Delete(int id);
        public Task<ProviderDto> Update(ProviderDto entity);
        public Task<IEnumerable<ProviderDto>> Get();
        public Task<ProviderDto> Get(int id);
    }
}
