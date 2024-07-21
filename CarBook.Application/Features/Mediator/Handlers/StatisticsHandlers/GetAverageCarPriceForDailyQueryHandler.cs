using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAverageCarPriceForDailyQueryHandler : IRequestHandler<GetAverageCarPriceForDailyQuery, GetAverageCarPriceForDailyQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetAverageCarPriceForDailyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAverageCarPriceForDailyQueryResult> Handle(GetAverageCarPriceForDailyQuery request, CancellationToken cancellationToken)
        {
            var amount = _repository.GetAverageCarPriceForDaily();
            return new GetAverageCarPriceForDailyQueryResult
            {
                AverageCarAmountDaily = amount
            };
        }
    }
}
