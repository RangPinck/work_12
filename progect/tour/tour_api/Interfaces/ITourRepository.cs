using tour_api.DTO;

namespace tour_api.Interfaces
{
    /// <summary>
    /// Интерфейс класса методов для работы с туром
    /// </summary>
    public interface ITourRepository
    {
        Task<ICollection<TourDTO>> GetTours();
    }
}
