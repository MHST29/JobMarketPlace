namespace JobMarketPlace.Domain.Entities
{
    public class Contractor
    {
        public Guid Id { get; set; }
        public string Name { get; set; } // business name
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
