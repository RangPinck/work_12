using tour_api.DTO;

namespace tour_api.Interfaces
{
    /// <summary>
    /// Интерфейс класса методов для работы с типами туров
    /// </summary>
    public interface ITourTypesRepository
    {
        /// <summary>
        /// Получение списка типов туров
        /// </summary>
        /// <returns>Список типов туров, соотвествующий модели TourTypesDTO</returns>
        Task<List<TourTypesDTO>> GetTourTypes();
    }
}
