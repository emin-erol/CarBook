using CarBook.Application.Features.Mediator.Queries.ReservationQueries;
using CarBook.Application.Features.Mediator.Results.ReservationResults;
using CarBook.Application.Interfaces.DashboardInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationDateQueryHandler : IRequestHandler<GetReservationDateQuery, List<GetReservationDateQueryResult>>
    {
        private readonly IDashboardRepository _repository;
        public GetReservationDateQueryHandler(IDashboardRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetReservationDateQueryResult>> Handle(GetReservationDateQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetReservationDates();
            return values.Select(x => new GetReservationDateQueryResult
            {
                Year = x.Key,
                Count = x.Value
            }).ToList();
        }
    }
}
