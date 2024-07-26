using CarBook.Application.Features.Mediator.Results.CarDescriptionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByCarQuery : IRequest<GetCarDescriptionByCarQueryResult>
    {
        public int Id { get; set; }

        public GetCarDescriptionByCarQuery(int id)
        {
            Id = id;
        }
    }
}
