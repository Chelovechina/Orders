namespace Orders.Domain.DTO
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public List<OrderDto>? Orders { get; set; }
    }
}
