using Microsoft.AspNetCore.Mvc;
using tour_api.DTO;
using tour_api.Interfaces;

namespace tour_api.Controllers
{
    [Route("tour_api/v1/[controller]")]
    [ApiController]
    public class TourController : Controller
    {
        private readonly ITourRepository _repository;

        public TourController(ITourRepository repository) => _repository = repository;

        [HttpGet("get_tour")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TourDTO>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CheckConnection()
        {
            var tours = await _repository.GetTours();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(tours);
        }
    }
}
