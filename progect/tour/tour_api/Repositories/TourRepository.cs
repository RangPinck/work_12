using Microsoft.EntityFrameworkCore;
using tour_api.DTO;
using tour_api.Interfaces;
using tour_api.Models;

namespace tour_api.Repositories
{
    /// <summary>
    /// Класс методов обращения к базе данных для работы с турами
    /// </summary>
    public class TourRepository : ITourRepository
    {
        private readonly _43pToursContext _context;

        public TourRepository(_43pToursContext context) => _context = context;

        /// <summary>
        /// Получение списка туров
        /// </summary>
        /// <returns>Список туров соотвествующий модели TourDTO</returns>
        public async Task<ICollection<TourDTO>> GetTours() => await _context.Tours.Select(x => new TourDTO()
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            ImagePreview = x.ImagePreview,
            Price = x.Price,
            TicketCount = x.TicketCount,
            IsActual = x.IsActual,
            IsActualText = x.IsActual == 1 ? "Актуален" : "Не актуален",
            Type = x.ToursTypes.Select(type => type.TypeId).ToList()
        }
        ).ToListAsync<TourDTO>();

    }
}
