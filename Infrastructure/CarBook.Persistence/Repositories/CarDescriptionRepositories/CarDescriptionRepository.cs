using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarDescriptionRepositories
{
	public class CarDescriptionRepository : ICarDescriptionRepository
	{
		private readonly CarBookContext _context;
		public CarDescriptionRepository(CarBookContext context)
		{
			_context = context;
		}
		public CarDescription GetCarDescriptionByCar(int carId)
		{
			var value = _context.Descriptions.Where(x => x.CarId == carId).FirstOrDefault();
			return value;
		}
	}
}
