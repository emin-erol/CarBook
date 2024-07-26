using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Application.Interfaces.CarDetailIntefaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarQueryHandler : IRequestHandler<GetCarDescriptionByCarQuery, GetCarDescriptionByCarQueryResult>
    {
        private readonly ICarDescriptionRepository _repository;
        public GetCarDescriptionByCarQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCarDescriptionByCarQueryResult> Handle(GetCarDescriptionByCarQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarDescriptionByCar(request.Id);
            return new GetCarDescriptionByCarQueryResult
            {
                CarDescriptionId = value.CarDescriptionId,
                CarId = value.CarId,
                Details = value.Details
            };
        }
    }
}
