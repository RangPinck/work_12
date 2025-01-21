using System.Diagnostics.CodeAnalysis;
using tour_api.Interfaces;
using tour_api.Models;

namespace tour_api.Repositories
{
    /// <summary>
    /// Класс мтеодов для обращения к базе данных с проверкой подключения
    /// </summary>
    public class ConnectionRepository : IConnectionRepository
    {
        private readonly _43pToursContext _context;

        public ConnectionRepository(_43pToursContext context)
        {
            this._context = context;
        }

        public async Task<bool> CheckConnectionDataBase() => await _context.Database.CanConnectAsync();
    }
}
