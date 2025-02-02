using Microsoft.AspNetCore.Mvc;
using tour_api.Interfaces;

namespace tour_api.Controllers
{
    /// <summary>
    /// Контроллер подключения API к базе данных
    /// </summary>
    [Route("tour_api/v1/[controller]")]
    [ApiController]
    public class ConnectionController : Controller
    {
        private readonly IConnectionRepository _repository;

        public ConnectionController(IConnectionRepository repository) => _repository = repository;

        /// <summary>
        /// Endpoint проверки подключения к базе данных из API
        /// </summary>
        /// <returns>
        /// true - API подключён к базе данных,
        /// false - API не подключён к базе данных
        /// </returns>
        [HttpGet("check_connection")]
        [ProducesResponseType(200, Type = typeof(Boolean))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CheckConnection()
        {
            bool isConnectDatabase = await _repository.CheckConnectionDataBase();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!isConnectDatabase)
            {
                ModelState.AddModelError("", "Couldn't connect to the database.");
                return StatusCode(400, ModelState);
            }

            return Ok(true);
        }
    }
}
