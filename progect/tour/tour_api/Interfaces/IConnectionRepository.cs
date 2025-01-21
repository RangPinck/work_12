namespace tour_api.Interfaces
{
    /// <summary>
    /// Интерфейс класса методов проверки подключения
    /// </summary>
    public interface IConnectionRepository
    {
        /// <summary>
        /// провекрка подкюлчения к базе данных
        /// </summary>
        /// <returns>
        /// true - подключение есть
        /// false - подключится не удалось
        /// </returns>
        Task<bool> CheckConnectionDataBase();
    }
}
