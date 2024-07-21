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
    public class GetCarCountByElectricCarQueryHandler :
        IRequestHandler<GetCarCountByElectricCarQuery, GetCarCountByElectricCarQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetCarCountByElectricCarQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCarCountByElectricCarQueryResult> Handle(GetCarCountByElectricCarQuery request, CancellationToken cancellationToken)
        {
            var carCount = _repository.GetCarCountByElectricCar();
            return new GetCarCountByElectricCarQueryResult
            {
                CarCountOfElectricCar = carCount
            };
        }
    }
}
