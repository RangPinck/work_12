using Microsoft.AspNetCore.Mvc;
using tour_api.DTO;
using tour_api.Interfaces;

namespace tour_api.Controllers
{
    /// <summary>
    /// Контроллер подключения управления странами
    /// </summary>
    [Route("tour_api/v1/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _repository;

        public CountryController(ICountryRepository repository) => _repository = repository;

        /// <summary>
        /// Endpoint получения списка стан
        /// </summary>
        /// <returns>список старн, соответсвующий модели CountryDTO</returns>
        [HttpGet("get_countries")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDTO>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCountryes()
        {
            var countryes = await _repository.GetCountries();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(countryes);
        }
    }
}
