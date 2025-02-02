using tour_api.DTO;

namespace tour_api.Interfaces
{
    /// <summary>
    /// Интерфейс класса методов для работы с отелями
    /// </summary>
    public interface IHotelRepository
    {
        /// <summary>
        /// Получение списка типов туров
        /// </summary>
        /// <returns>Список типов туров, соотвествующий модели TourTypesDTO</returns>
        Task<List<HotelFullDTO>> GetFullDataHotels();

        /// <summary>
        /// Добавление отеля в базу данных
        /// </summary>
        /// <param name="hotel">Данные отелся, соотвествующие модели HotelShortDTO</param>
        /// <returns>
        /// true - отель был добавлен,
        /// false - произошла ошибка на стороне базы данных
        /// </returns>
        Task<bool> AddHotel(HotelShortDTO hotel);

        /// <summary>
        /// Обновление отеля в базе данных
        /// </summary>
        /// <param name="hotel">Данные отелся, соотвествующие модели HotelShortDTO</param>
        /// <returns>
        /// true - отель был изменён,
        /// false - произошла ошибка на стороне базы данных
        /// </returns>
        Task<bool> UpdateHotel(HotelShortDTO hotel);

        /// <summary>
        /// Удаление отеля из базы данных
        /// </summary>
        /// <param name="hotelId">id удаляемого отеля</param>
        /// <returns>
        /// true - отель был удалён,
        /// false - произошла ошибка на стороне базы данных
        /// </returns>
        Task<bool> DeleteHotel(int hotelId);

        /// <summary>
        /// Проверка наличия отеля по его id
        /// </summary>
        /// <param name="hotelId">id искомого отеля</param>
        /// <returns>
        /// true - отель был найден,
        /// false - отель не был найден
        /// </returns>
        Task<bool> HotelIsExist(int hotelId);

        /// <summary>
        /// Проверка наличия отеля по его основным данным
        /// </summary>
        /// <param name="hotelId">Данные отелся, соотвествующие модели HotelShortDTO</param>
        /// <returns>
        /// true - отель был найден,
        /// false - отель не был найден
        /// </returns>
        Task<bool> HotelIsExist(HotelShortDTO hotel);

        /// <summary>
        /// Проверка наличия страны по её коду
        /// </summary>
        /// <param name="hotelId">код искомой страны</param>
        /// <returns>
        /// true - страна была найдена,
        /// false - страна не была найдена
        /// </returns>
        Task<bool> CountryIsExist(string countryCode);

        /// <summary>
        /// Проверка на то, изменились ли данные отеля
        /// </summary>
        /// <param name="hotel">новые данные отеля по модели HotelShortDTO</param>
        /// <returns>
        /// true - данные были изменены,
        /// false - данные не были изменены
        /// </returns>
        Task<bool> CheckHotelUpdate(HotelShortDTO hotel);
    }
}
