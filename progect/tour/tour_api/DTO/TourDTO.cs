namespace tour_api.DTO
{
    public class TourDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImagePreview { get; set; }
        public int Price { get; set; }
        public int TicketCount { get; set; }
        public string Type { get; set; } = null!;
        public int IsActual { get; set; }
    }
}