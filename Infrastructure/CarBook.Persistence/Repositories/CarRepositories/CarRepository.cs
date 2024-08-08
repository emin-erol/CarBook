using AutoMapper;
using CarBook.Application.Interfaces.CarIntefaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;
        private readonly IMapper _mapper;
        public CarRepository(CarBookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int GetCarCount()
        {
            int count = _context.Cars.Count();
            return count;
        }

        public List<Car> GetCarListWithBrand()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }

        public List<Car> GetLast5CarsWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).Include(y => y.CarPricings).ThenInclude(z => z.Pricing).ToList();
            return values;
        }

        public async Task<string> GetCarDescription(int id)
        {
            var value = await _context.Cars
                .Where(x => x.CarId == id)
                .Select(x => x.Description)
                .FirstOrDefaultAsync();
            
            return value;
        }
    }
}
