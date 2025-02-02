using Microsoft.EntityFrameworkCore;
using tour_api.DTO;
using tour_api.Interfaces;
using tour_api.Models;

namespace tour_api.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly _43pToursContext _context;

        public CountryRepository(_43pToursContext context) => _context = context;

        public async Task<List<CountryDTO>> GetCountries() => await _context.Countries.Select(country => new CountryDTO()
        {
            Code = country.Code,
            Country = country.Country1
        }).ToListAsync();
    }
}
