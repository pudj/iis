namespace Zadatak2.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public int EventId { get; set; }
        public int VenueId { get; set; }
    }
}
