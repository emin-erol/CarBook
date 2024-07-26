using CarBook.Application.Interfaces.CarDetailIntefaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarDetailRepositories
{
	public class CarDetailRepository : ICarDetailRepository
	{
		private readonly CarBookContext _context;
		public CarDetailRepository(CarBookContext context)
		{
			_context = context;
		}
		
		public Car GetMainCarDetailsByCar(int carId)
		{
			var value = _context.Cars.Include(x => x.Brand).Where(x => x.CarId == carId).FirstOrDefault();
			return value;
		}
		public CarDescription GetCarDescriptionByCar(int carId)
		{
			var value = _context.Descriptions.Where(x => x.CarId == carId).FirstOrDefault();
			return value;
		}
	}
}
