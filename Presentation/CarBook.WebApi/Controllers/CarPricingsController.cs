using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCarPricingWithCarsList()
        {
            var values = await _mediator.Send(new GetCarPricingWithCarsQuery());
            return Ok(values);
        }
		[HttpGet("GetCarPricingWithTimePeriodList")]
		public async Task<IActionResult> GetCarPricingWithTimePeriodList()
		{
			var values = await _mediator.Send(new GetCarPricingTimePeriodQuery());
			return Ok(values);
		}
        [HttpGet("GetLast5CarsWithBrandsList")]
        public async Task<IActionResult> GetLast5CarsWithBrandsList()
        {
            var values = await _mediator.Send(new GetLast5CarsWithBrandsQuery());
            return Ok(values);
        }
    }
}
