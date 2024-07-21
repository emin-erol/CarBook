using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarIntefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandsQueryHandler
    {
        private readonly ICarRepository _repository;
        public GetLast5CarsWithBrandsQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<GetLast5CarsWithBrandsQueryResult> Handle()
        {
            var values = _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetLast5CarsWithBrandsQueryResult
            {
                CarId = x.CarId,
                BrandId = x.BrandId,
                BrandName = x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Luggage = x.Luggage,
                Mileage = x.Mileage,
                Model = x.Model,
                Transmission = x.Transmission,
                Seat = x.Seat
            }).ToList();
        }
    }
}
