﻿using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }
        [HttpGet("CarFeatureChangeToFalse")]
        public async Task<IActionResult> CarFeatureChangeToFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Car Feature Available Information Has Been Updated!");
        }
        [HttpGet("CarFeatureChangeToTrue")]
        public async Task<IActionResult> CarFeatureChangeToTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Car Feature Available Information Has Been Updated!");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCar(CreateCarFeatureByCarCommand command)
        {
            _mediator.Send(command);
            return Ok("Car Feature Information Has Been Created!");
        }
    }
}
