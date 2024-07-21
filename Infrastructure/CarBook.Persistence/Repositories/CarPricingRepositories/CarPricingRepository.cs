using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;
        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }
        public List<CarPricing> GetCarPricingsWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car)
                .ThenInclude(y => y.Brand).Include(z => z.Pricing)
                .Where(z => z.PricingId == 1).ToList();
            return values;
        }

		public List<CarPricingViewModel> GetCarPricingTimePeriod()
		{
			var query = from carPricing in _context.CarPricings
						join car in _context.Cars
						on carPricing.CarId equals car.CarId
						join brand in _context.Brands on car.BrandId
						equals brand.BrandId
						select new
						{
							car.CarId,
							brand.Name,
							car.Model,
							car.CoverImageUrl,
							carPricing.PricingId,
							carPricing.Amount
						};
			var data = query.ToList();
			var pivotData = data
				.GroupBy(d => new { d.CarId, d.Name, d.Model, d.CoverImageUrl })
				.Select(g => new CarPricingViewModel
				{
					CarId = g.Key.CarId,
					BrandName = g.Key.Name,
					Model = g.Key.Model,
					CoverImageUrl = g.Key.CoverImageUrl,
					Amounts = g.OrderBy(x => x.PricingId)
										.Select(x => x.Amount)
										.ToList()
				})
				.ToList();
			return pivotData;
		}

        public List<CarPricing> GetLast5CarsWithBrands()
        {
            var values = _context.CarPricings.Include(x => x.Car)
                .ThenInclude(y => y.Brand).Include(z => z.Pricing)
                .Where(z => z.PricingId == 1).ToList();
            return values;
        }

        //public List<CarPricingViewModel> GetCarPricingTimePeriod()
        //{
        //	List<CarPricingViewModel> values = new List<CarPricingViewModel>();
        //	using (var command = _context.Database.GetDbConnection().CreateCommand())
        //	{
        //		command.CommandText = "SELECT * FROM (SELECT Model,CoverImageUrl,PricingId,Amount FROM CarPricings INNER JOIN Cars ON Cars.CarId=CarPricings.CarId INNER " +
        //			"JOIN Brands ON Brands.BrandId=Cars.BrandId) AS SourceTable Pivot (Sum(Amount) For PricingId IN ([1],[2],[3])) AS PivotTable";
        //		command.CommandType = System.Data.CommandType.Text;
        //		_context.Database.OpenConnection();
        //		using (var reader = command.ExecuteReader())
        //		{
        //			while (reader.Read())
        //			{
        //				CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
        //				{
        //					Model = reader["Model"].ToString(),
        //					CoverImageUrl = reader["CoverImageUrl"].ToString(),
        //					Amounts = new List<decimal>
        //					{
        //						Convert.ToDecimal(reader[1]),
        //						Convert.ToDecimal(reader[2]),
        //						Convert.ToDecimal(reader[3])
        //					}
        //				};
        //				values.Add(carPricingViewModel);
        //			}
        //		}
        //		_context.Database.CloseConnection();
        //		return values;
        //	}
        //}
    }
}
