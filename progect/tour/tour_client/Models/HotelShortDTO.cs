namespace tour_api.DTO
{
    /// <summary>
    /// Модель вывода с сокращённой информацией о отелях
    /// </summary>
    public class HotelShortDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CountOfStars { get; set; }

        public string CountryCode { get; set; } = null!;

        public string? Description { get; set; }
    }
}
