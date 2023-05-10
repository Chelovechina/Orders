namespace Orders.Domain.DTO
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
    }
}
