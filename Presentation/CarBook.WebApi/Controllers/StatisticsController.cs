using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var value = await _mediator.Send(new GetCarCountQuery());
            return Ok(value);
        }
        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var value = await _mediator.Send(new GetLocationCountQuery());
            return Ok(value);
        }
        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var value = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(value);
        }
        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var value = await _mediator.Send(new GetBlogCountQuery());
            return Ok(value);
        }
        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var value = await _mediator.Send(new GetBrandCountQuery());
            return Ok(value);
        }
        [HttpGet("GetReferenceCount")]
        public async Task<IActionResult> GetReferenceCount()
        {
            var value = await _mediator.Send(new GetReferenceCountQuery());
            return Ok(value);
        }
        [HttpGet("GetAverageCarPriceForDaily")]
        public async Task<IActionResult> GetAverageCarPriceForDaily()
        {
            var value = await _mediator.Send(new GetAverageCarPriceForDailyQuery());
            return Ok(value);
        }
        [HttpGet("GetAverageCarPriceForWeekly")]
        public async Task<IActionResult> GetAverageCarPriceForWeekly()
        {
            var value = await _mediator.Send(new GetAverageCarPriceForWeeklyQuery());
            return Ok(value);
        }
        [HttpGet("GetAverageCarPriceForMonthly")]
        public async Task<IActionResult> GetAverageCarPriceForMonthly()
        {
            var value = await _mediator.Send(new GetAverageCarPriceForMonthlyQuery());
            return Ok(value);
        }
        [HttpGet("BrandNameByMaxCar")]
        public async Task<IActionResult> BrandNameByMaxCar()
        {
            var value = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(value);
        }
        [HttpGet("BlogTitleByMaxBlogComment")]
        public async Task<IActionResult> BlogTitleByMaxBlogComment()
        {
            var value = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByMileageSmallerThenInterval")]
        public async Task<IActionResult> GetCarCountByMileageSmallerThenInterval()
        {
            var value = await _mediator.Send(new GetCarCountByMileageSmallerThenIntervalQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFuelGasolineOrDiesel()
        {
            var value = await _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(value);
        }
        [HttpGet("GetCarCountByElectricCar")]
        public async Task<IActionResult> GetCarCountByElectricCar()
        {
            var value = await _mediator.Send(new GetCarCountByElectricCarQuery());
            return Ok(value);
        }
        [HttpGet("GetMostExpensiveAndCheapCarDaily")]
        public async Task<IActionResult> GetMostExpensiveAndCheapCarDaily()
        {
            var value = await _mediator.Send(new GetMostExpensiveAndCheapCarDailyQuery());
            return Ok(value);
        }
    }
}
