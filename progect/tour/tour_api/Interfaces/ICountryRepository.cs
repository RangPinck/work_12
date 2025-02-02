using tour_api.DTO;

namespace tour_api.Interfaces
{
    /// <summary>
    /// Интерфейс класса методов для работы со странами
    /// </summary>
    public interface ICountryRepository
    {
        /// <summary>
        /// Получение списка стран
        /// </summary>
        /// <returns>Список стан, соотвесвующий модели CountryDTO</returns>
        Task<List<CountryDTO>> GetCountries();
    }
}
