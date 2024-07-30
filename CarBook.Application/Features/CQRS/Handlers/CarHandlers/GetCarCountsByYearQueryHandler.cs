using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.DashboardInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarCountsByYearQueryHandler
    {
        private readonly IDashboardRepository _repository;
        public GetCarCountsByYearQueryHandler(IDashboardRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarCountsByYearQueryResult>> Handle()
        {
            var values = await _repository.GetCarCountsByYear();
            return values.Select(x => new GetCarCountsByYearQueryResult
            {
                Year = x.Key,
                Count = x.Value
            }).ToList();
        }
    }
}
