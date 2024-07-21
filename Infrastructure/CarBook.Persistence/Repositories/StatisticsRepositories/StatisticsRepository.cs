using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }
        public int GetCarCount()
        {
            int carCount = _context.Cars.Count();
            return carCount;
        }
        public int GetLocationCount()
        {
            int locationCount = _context.Locations.Count();
            return locationCount;
        }
        public int GetAuthorCount()
        {
            int authorCount = _context.Authors.Count();
            return authorCount;
        }
        public int GetBlogCount()
        {
            int blogCount = _context.Blogs.Count();
            return blogCount;
        }
        public int GetBrandCount()
        {
            int brandCount = _context.Brands.Count();
            return brandCount;
        }
        public int GetReferenceCount()
        {
            int referenceCount = _context.Testimonials.Count();
            return referenceCount;
        }
        public decimal GetAverageCarPriceForDaily()
        {
            decimal price = _context.CarPricings.Where(x => x.PricingId == 1).Average(y => y.Amount);
            return price;
        }
        public decimal GetAverageCarPriceForWeekly()
        {
            decimal price = _context.CarPricings.Where(x => x.PricingId == 2).Average(y => y.Amount);
            return price;
        }
        public decimal GetAverageCarPriceForMonthly()
        {
            decimal price = _context.CarPricings.Where(x => x.PricingId == 3).Average(y => y.Amount);
            return price;
        }
        public string BrandNameByMaxCar()
        {
            var brandId = _context.Cars
                .GroupBy(x => x.BrandId)
                .OrderByDescending(y => y.Count())
                .Select(y => y.Key)
                .FirstOrDefault();
            var brandName = _context.Brands.FirstOrDefault(x => x.BrandId == brandId)?.Name;
            return brandName;
        }
        public string BlogTitleByMaxBlogComment()
        {
            var blogId = _context.Comments
                .GroupBy(x => x.BlogId)
                .OrderByDescending(y => y.Count())
                .Select(y => y.Key)
                .FirstOrDefault();
            var blogTitle = _context.Blogs.FirstOrDefault(x => x.BlogId == blogId)?.Title;
            return blogTitle;
        }

        public int GetCarCountByMileageSmallerThenInterval()
        {
            var carCount = _context.Cars.Count(x => x.Mileage < 100000);
            return carCount;
        }

        public List<int> GetCarCountByFuelGasolineOrDiesel()
        {
            var counts = new List<int>();
            int gasolineCount = _context.Cars.Count(c => c.Fuel == "Benzin");
            int dieselCount = _context.Cars.Count(c => c.Fuel == "Dizel");
            counts.Add(gasolineCount);
            counts.Add(dieselCount);
            return counts;
        }

        public int GetCarCountByElectricCar()
        {
            var count = _context.Cars.Count(x => x.Fuel == "Elektrik");
            return count;
        }

        public List<string> GetMostExpensiveAndCheapCarDaily()
        {
            int cheapCarId = _context.CarPricings.Where(x => x.PricingId == 1).OrderBy(a => a.Amount).FirstOrDefault().CarId;
            int expensiveCarId = _context.CarPricings.Where(x => x.PricingId == 1).OrderByDescending(a => a.Amount).FirstOrDefault().CarId;
            List<int> ids = new List<int> { cheapCarId, expensiveCarId };

            List<string> brands = _context.Cars
                .Where(x => ids.Contains(x.CarId))
                .Select(x => new { BrandId = x.BrandId, Model = x.Model })
                .Join(_context.Brands,
                    y => y.BrandId,
                    z => z.BrandId,
                    (y, z) => $"{z.Name} {y.Model}")
                .ToList();

            List<decimal> amounts = _context.CarPricings
                .Where(x => ids.Contains(x.CarId))
                .Select(x => x.Amount)
                .ToList();

            var values = brands.Zip(amounts, (str, num) => $"{str} - {num}").ToList();

            return values;
        }

        
    }
}
