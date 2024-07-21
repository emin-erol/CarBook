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
    public class GetMostExpensiveAndCheapCarDailyQueryHandler : IRequestHandler<GetMostExpensiveAndCheapCarDailyQuery, GetMostExpensiveAndCheapCarDailyQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetMostExpensiveAndCheapCarDailyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetMostExpensiveAndCheapCarDailyQueryResult> Handle(GetMostExpensiveAndCheapCarDailyQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetMostExpensiveAndCheapCarDaily();
            return new GetMostExpensiveAndCheapCarDailyQueryResult
            {
                MostCheapAndExpensiveCar = values
            };
        }
    }
}
