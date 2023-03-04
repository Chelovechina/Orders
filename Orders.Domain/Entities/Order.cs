namespace Orders.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}
