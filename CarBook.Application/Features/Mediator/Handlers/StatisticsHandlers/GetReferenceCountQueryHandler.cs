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
    public class GetReferenceCountQueryHandler : IRequestHandler<GetReferenceCountQuery, GetReferenceCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetReferenceCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetReferenceCountQueryResult> Handle(GetReferenceCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetReferenceCount();
            return new GetReferenceCountQueryResult
            {
                ReferenceCount = value
            };
        }
    }
}
