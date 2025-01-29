using tour_api.DTO;
using tour_api.Interfaces;
using tour_api.Models;

namespace tour_api.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly _43pToursContext _context;

        public TourRepository(_43pToursContext context)
        {
            this._context = context;
        }

        //public Task<ICollection<TourDTO>> GetTours()
        //{
        //    return List<TourDTO>();
        //}
    }
}
