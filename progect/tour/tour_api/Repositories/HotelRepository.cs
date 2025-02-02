using Microsoft.EntityFrameworkCore;
using tour_api.DTO;
using tour_api.Interfaces;
using tour_api.Models;

namespace tour_api.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly _43pToursContext _context;

        public HotelRepository(_43pToursContext context) => _context = context;

        public async Task<bool> AddHotel(HotelShortDTO hotel)
        {
            var newHotel = new Hotel()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                CountOfStars = hotel.CountOfStars,
                CountryCode = hotel.CountryCode,
                Description = hotel.Description
            };

            await _context.Hotels.AddAsync(newHotel);

            return await SaveChenges();
        }

        public async Task<bool> CheckHotelUpdate(HotelShortDTO hotel)
        {
            Hotel hotelInDataBase = await _context.Hotels.FirstAsync(x => x.Id == hotel.Id);

            if (hotel.Name != hotelInDataBase.Name) return true;
            if (hotel.CountOfStars != hotelInDataBase.CountOfStars) return true;
            if (hotel.CountryCode != hotelInDataBase.CountryCode) return true;
            if (hotel.Description != hotelInDataBase.Description) return true;

            return false;
        }

        public async Task<bool> CountryIsExist(string countryCode)
        {
            return await _context.Countries.AnyAsync(coutry => coutry.Code == countryCode);
        }

        public async Task<bool> DeleteHotel(int hotelId)
        {
            Hotel hotelDelete = await _context.Hotels.FirstAsync(hotel => hotel.Id == hotelId);

            _context.Hotels.Remove(hotelDelete);

            return await SaveChenges();
        }

        public async Task<List<HotelFullDTO>> GetFullDataHotels() => await _context.Hotels.Select(hotel => new HotelFullDTO()
        {
            Id = hotel.Id,
            Name = hotel.Name,
            CountOfStars = hotel.CountOfStars,
            CountryCode = hotel.CountryCode,
            Country = hotel.CountryCodeNavigation.Country1,
            Description = hotel.Description
        }).ToListAsync();

        public async Task<bool> HotelIsExist(int hotelId)
        {
            return await _context.Hotels.AnyAsync(x => x.Id == hotelId);
        }

        public async Task<bool> HotelIsExist(HotelShortDTO hotel)
        {
            return await _context.Hotels.AnyAsync(x => x.Name == hotel.Name && (x.CountryCode == hotel.CountryCode));
        }

        public async Task<bool> UpdateHotel(HotelShortDTO hotel)
        {
            Hotel hotelUpdate = await _context.Hotels.FirstAsync(x => hotel.Id == x.Id);

            hotelUpdate.Name = hotel.Name;
            hotelUpdate.CountryCode = hotel.CountryCode;
            hotelUpdate.CountOfStars = hotel.CountOfStars;
            hotelUpdate.Description = hotel.Description;

            return await SaveChenges();
        }

        /// <summary>
        /// Сохранение изменений в базе данных
        /// </summary>
        /// <returns>
        /// true - в базе данных сохранено измение одной или более записей,
        /// fales - в базе данных изменений не произошло
        /// </returns>
        private async Task<bool> SaveChenges()
        {
            var save = await _context.SaveChangesAsync();
            return save > 0;
        }
    }
}
