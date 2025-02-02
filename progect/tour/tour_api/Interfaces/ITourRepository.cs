using tour_api.DTO;

namespace tour_api.Interfaces
{
    /// <summary>
    /// Интерфейс класса методов для работы с турами
    /// </summary>
    public interface ITourRepository
    {
        /// <summary>
        /// Получение списка туров
        /// </summary>
        /// <returns>Список туров, соотвествующий модели TourDTO</returns>
        Task<ICollection<TourDTO>> GetTours();
    }
}
