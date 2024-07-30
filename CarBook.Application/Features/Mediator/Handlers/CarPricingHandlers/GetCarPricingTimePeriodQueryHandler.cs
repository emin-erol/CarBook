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
	public class GetCarPricingTimePeriodQueryHandler : IRequestHandler<GetCarPricingTimePeriodQuery, List<GetCarPricingTimePeriodQueryResult>>
	{
		private readonly ICarPricingRepository _repository;
		public GetCarPricingTimePeriodQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}
		public async Task<List<GetCarPricingTimePeriodQueryResult>> Handle(GetCarPricingTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var values = _repository.GetCarPricingTimePeriod();
			return values.Select(x => new GetCarPricingTimePeriodQueryResult
			{
				CarId = x.CarId,
				BrandName = x.BrandName,
				Model = x.Model,
				Year = x.Year,
				CoverImageUrl = x.CoverImageUrl,
				DailyAmount = x.Amounts[0],
				WeeklyAmount = x.Amounts[1],
				MonthlyAmount = x.Amounts[2],
			}).ToList();
		}
	}
}
