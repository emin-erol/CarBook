using CarBook.Application.Interfaces.DashboardInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.DashboardRepositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly CarBookContext _context;
        public DashboardRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task<Dictionary<int,int>> GetReservationDates()
        {
            var yearlyCounts = await _context.Reservations
                .GroupBy(r => r.ReservationDate.Year)
                .Select(g => new
                {
                    Year = g.Key,
                    Count = g.Count()
                })
                .ToDictionaryAsync(x => x.Year, x => x.Count);
            return yearlyCounts;
        }
        public async Task<Dictionary<string, int>> GetCarCountsInLocation()
        {
            var result = await _context.RentACars
                .GroupBy(rac => rac.LocationId)
                .Select(g => new
                {
                    LocationName = _context.Locations
                        .Where(loc => loc.LocationId == g.Key)
                        .Select(loc => loc.Name)
                        .FirstOrDefault(),
                    CarCount = g.Count()
                })
                .ToListAsync();
            var carCounts = result.ToDictionary(
                item => item.LocationName,
                item => item.CarCount
            );
            return carCounts;
        }

        public async Task<Dictionary<int, int>> GetCarCountsByYear()
        {
            var results = await _context.Cars
                .GroupBy(c => c.Year)
                .Select(group => new
                {
                    Year = group.Key,
                    Count = group.Count()
                })
                .ToDictionaryAsync(g => g.Year, g => g.Count);
            return results;
        }
    }
}
