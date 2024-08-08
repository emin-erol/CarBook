using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarIntefaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarDescriptionQueryHandler
    {
        private readonly ICarRepository _cR;
        public GetCarDescriptionQueryHandler(ICarRepository cR)
        {
            _cR = cR;
        }

        public async Task<GetCarDescriptionQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await _cR.GetCarDescription(query.Id);
            return new GetCarDescriptionQueryResult
            {
                Description = value
            };
        }
    }
}
