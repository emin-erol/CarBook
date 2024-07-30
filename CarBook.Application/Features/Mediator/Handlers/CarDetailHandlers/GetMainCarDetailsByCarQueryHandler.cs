using CarBook.Application.Features.Mediator.Queries.CarDetailQueries;
using CarBook.Application.Features.Mediator.Results.CarDetailResults;
using CarBook.Application.Interfaces.CarDetailIntefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDetailHandlers
{
	public class GetMainCarDetailsByCarQueryHandler : IRequestHandler<GetMainCarDetailsByCarQuery, GetMainCarDetailsByCarQueryResult>
	{
		private readonly ICarDetailRepository _repository;
		public GetMainCarDetailsByCarQueryHandler(ICarDetailRepository repository)
		{
			_repository = repository;
		}
		public async Task<GetMainCarDetailsByCarQueryResult> Handle(GetMainCarDetailsByCarQuery request, CancellationToken cancellationToken)
		{
			var value = _repository.GetMainCarDetailsByCar(request.Id);
			return new GetMainCarDetailsByCarQueryResult
			{
				CarId = value.CarId,
				BrandId = value.BrandId,
				BrandName = value.Brand.Name,
				Mileage = value.Mileage,
				Year = value.Year,
				Fuel = value.Fuel,
				BigImageUrl = value.BigImageUrl,
				Luggage = value.Luggage,
				Model = value.Model,
				Seat = value.Seat,
				Transmission = value.Transmission
			};
		}
	}
}
