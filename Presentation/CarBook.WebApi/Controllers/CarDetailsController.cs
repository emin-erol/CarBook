using CarBook.Application.Features.Mediator.Queries.CarDetailQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDetailsController : ControllerBase
	{
		private readonly IMediator _mediator;
		public CarDetailsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetMainCarDetailsByCar(int id)
		{
			var value = await _mediator.Send(new GetMainCarDetailsByCarQuery(id));
			return Ok(value);
		}
	}
}
