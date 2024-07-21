using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetLast5CarsWithBrandsQueryHandler : IRequestHandler<GetLast5CarsWithBrandsQuery, List<GetLast5CarsWithBrandsQueryResult>>
    {
        private readonly ICarPricingRepository _repository;
        public GetLast5CarsWithBrandsQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetLast5CarsWithBrandsQueryResult>> Handle(GetLast5CarsWithBrandsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetLast5CarsWithBrandsQueryResult
            {
                CarId = x.CarId,
                CarPricingId = x.CarPricingId,
                Brand = x.Car.Brand.Name,
                Model = x.Car.Model,
                Amount = x.Amount,
                CoverImageUrl = x.Car.CoverImageUrl
            }).ToList();
        }
    }
}
