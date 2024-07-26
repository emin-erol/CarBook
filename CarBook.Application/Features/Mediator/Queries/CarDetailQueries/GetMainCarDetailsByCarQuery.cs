using CarBook.Application.Features.Mediator.Results.CarDetailResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarDetailQueries
{
	public class GetMainCarDetailsByCarQuery : IRequest<GetMainCarDetailsByCarQueryResult>
	{
        public int Id { get; set; }
		public GetMainCarDetailsByCarQuery(int id)
		{
			Id = id;
		}
	}
}
