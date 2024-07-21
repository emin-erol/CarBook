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
    public class GetAverageCarPriceForMonthlyQueryHandler : IRequestHandler<GetAverageCarPriceForMonthlyQuery, GetAverageCarPriceForMonthlyQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetAverageCarPriceForMonthlyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetAverageCarPriceForMonthlyQueryResult> Handle(GetAverageCarPriceForMonthlyQuery request, CancellationToken cancellationToken)
        {
            var amount = _repository.GetAverageCarPriceForMonthly();
            return new GetAverageCarPriceForMonthlyQueryResult
            {
                AverageCarAmountMonthly = amount
            };
        }
    }
}
