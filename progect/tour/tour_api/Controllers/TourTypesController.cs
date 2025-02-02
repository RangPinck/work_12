using Microsoft.AspNetCore.Mvc;
using tour_api.DTO;
using tour_api.Interfaces;

namespace tour_api.Controllers
{
    [Route("tour_api/v1/[controller]")]
    [ApiController]
    public class TourTypesController : Controller
    {
        private readonly ITourTypesRepository _repository;

        public TourTypesController(ITourTypesRepository repository) => _repository = repository;

        [HttpGet("get_tours_types")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TourTypesDTO>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CheckConnection()
        {
            var tours = await _repository.GetTourTypes();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(tours);
        }
    }
}
