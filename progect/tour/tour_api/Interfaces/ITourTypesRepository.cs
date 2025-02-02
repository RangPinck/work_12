using tour_api.DTO;

namespace tour_api.Interfaces
{
    public interface ITourTypesRepository
    {
        Task<List<TourTypesDTO>> GetTourTypes();
    }
}
