namespace Orders.Domain.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
    }
}
