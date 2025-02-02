using Microsoft.AspNetCore.Mvc;
using tour_api.DTO;
using tour_api.Interfaces;

namespace tour_api.Controllers
{
    /// <summary>
    /// Контроллер подключения управления отелями
    /// </summary>
    [Route("tour_api/v1/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        private readonly IHotelRepository _repository;

        public HotelController(IHotelRepository repository) => _repository = repository;

        /// <summary>
        /// Endpoint получения списка отелей
        /// </summary>
        /// <returns>список отелей, соответсвующий модели HotelFullDTO</returns>
        [HttpGet("get_hotels")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HotelFullDTO>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCountryes()
        {
            var countryes = await _repository.GetFullDataHotels();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(countryes);
        }

        [HttpPost("add_hotel")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddHotel(HotelShortDTO hotel)
        {
            if (await _repository.HotelIsExist(hotel))
            {
                return BadRequest("This hotel already exist.");
            }

            if (string.IsNullOrEmpty(hotel.Name))
            {
                return BadRequest("A hotel cannot exist without name.");
            }

            if (string.IsNullOrEmpty(hotel.CountryCode))
            {
                return BadRequest("A hotel cannot exist without country.");
            }

            if (string.IsNullOrEmpty(hotel.Description))
            {
                return BadRequest("A hotel cannot exist without description.");
            }

            if (hotel.CountOfStars > 5 || hotel.CountOfStars < 0)
            {
                return BadRequest("The hotels count stars of issue cannot be longer than the five and cannot be less zero.");
            }

            if (!await _repository.CountryIsExist(hotel.CountryCode))
            {
                return BadRequest("This country doesnt exists.");
            }

            if (!await _repository.AddHotel(hotel))
            {
                ModelState.AddModelError("", "This hotel doesnt add to database. No correct data.");
                return StatusCode(400, ModelState);
            }

            return Ok("Operation success");
        }

        [HttpPut("update_hotel")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateHotel(HotelShortDTO hotel)
        {
            if (!await _repository.HotelIsExist(hotel.Id))
            {
                return BadRequest("This book cannot exist.");
            }

            if (string.IsNullOrEmpty(hotel.Name))
            {
                return BadRequest("A hotel cannot exist without name.");
            }

            if (string.IsNullOrEmpty(hotel.CountryCode))
            {
                return BadRequest("A hotel cannot exist without country.");
            }

            if (string.IsNullOrEmpty(hotel.Description))
            {
                return BadRequest("A hotel cannot exist without description.");
            }

            if (hotel.CountOfStars > 5 || hotel.CountOfStars < 0)
            {
                return BadRequest("The hotels count stars of issue cannot be longer than the five and cannot be less zero.");
            }

            if (!await _repository.CountryIsExist(hotel.CountryCode))
            {
                return BadRequest("This country doesnt exists.");
            }

            if (await _repository.CheckHotelUpdate(hotel))
            {
                if (!await _repository.UpdateHotel(hotel))
                {
                    ModelState.AddModelError("", "This hotel doesnt update. No correct data.");
                    return StatusCode(400, ModelState);
                }
            }

            return Ok("Operation success");
        }

        [HttpDelete("delete_hotel")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteHotel(int hotelId)
        {
            if (!await _repository.HotelIsExist(hotelId))
            {
                return BadRequest("This hotel cannot exist.");
            }

            if (!await _repository.DeleteHotel(hotelId))
            {
                ModelState.AddModelError("", "This hotel doesn't delete. No correct data.");
                return StatusCode(400, ModelState);
            }

            return Ok("Operation success");
        }
    }
}


