namespace tour_api.DTO
{
    /// <summary>
    /// Модель вывода полной информации об отелях
    /// </summary>
    public class HotelFullDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CountOfStars { get; set; }

        public string CountryCode { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string? Description { get; set; }
    }
}
