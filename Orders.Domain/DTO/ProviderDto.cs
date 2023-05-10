namespace Orders.Domain.DTO
{
    public class ProviderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<OrderDto>? Orders { get; set; }
    }
}
