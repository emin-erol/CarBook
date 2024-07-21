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
    public class GetCarCountByMileageSmallerThenIntervalQueryHandler :
        IRequestHandler<GetCarCountByMileageSmallerThenIntervalQuery, GetCarCountByMileageSmallerThenIntervalQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetCarCountByMileageSmallerThenIntervalQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCarCountByMileageSmallerThenIntervalQueryResult> Handle(GetCarCountByMileageSmallerThenIntervalQuery request, CancellationToken cancellationToken)
        {
            var carCount = _repository.GetCarCountByMileageSmallerThenInterval();
            return new GetCarCountByMileageSmallerThenIntervalQueryResult
            {
                CarCountOfLessMileage = carCount
            };
        }
    }
}
