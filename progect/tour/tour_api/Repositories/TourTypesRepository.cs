using Microsoft.EntityFrameworkCore;
using tour_api.DTO;
using tour_api.Interfaces;
using tour_api.Models;

namespace tour_api.Repositories
{
    /// <summary>
    /// Класс методов обращения к базе данных для работы с типами туров
    /// </summary>
    public class TourTypesRepository : ITourTypesRepository
    {
        private readonly _43pToursContext _context;

        public TourTypesRepository(_43pToursContext context) => _context = context;

        /// <summary>
        /// Получение списка типов туров
        /// </summary>
        /// <returns>Список типов туров соотвествующий модели TourTypesDTO</returns>
        public async Task<List<TourTypesDTO>> GetTourTypes() => await _context.Types.Select(type => new TourTypesDTO()
        {
            Id = type.Id,
            Type = type.Type1
        }
        ).ToListAsync();
    }
}
