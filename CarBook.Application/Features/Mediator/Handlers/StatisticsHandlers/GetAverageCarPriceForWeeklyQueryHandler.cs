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
    public class GetAverageCarPriceForWeeklyQueryHandler : IRequestHandler<GetAverageCarPriceForWeeklyQuery, GetAverageCarPriceForWeeklyQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetAverageCarPriceForWeeklyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAverageCarPriceForWeeklyQueryResult> Handle(GetAverageCarPriceForWeeklyQuery request, CancellationToken cancellationToken)
        {
            var amount = _repository.GetAverageCarPriceForWeekly();
            return new GetAverageCarPriceForWeeklyQueryResult
            {
                AverageCarAmountWeekly = amount
            };
        }
    }
}
