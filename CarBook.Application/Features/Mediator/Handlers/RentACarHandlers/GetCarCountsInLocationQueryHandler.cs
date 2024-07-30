using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces.DashboardInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetCarCountsInLocationQueryHandler : IRequestHandler<GetCarCountsInLocationQuery, List<GetCarCountsInLocationQueryResult>>
    {
        private readonly IDashboardRepository _repository;
        public GetCarCountsInLocationQueryHandler(IDashboardRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarCountsInLocationQueryResult>> Handle(GetCarCountsInLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarCountsInLocation();
            return values.Select(x => new GetCarCountsInLocationQueryResult
            {
                LocationName = x.Key,
                Count = x.Value
            }).ToList();
        }
    }
}
