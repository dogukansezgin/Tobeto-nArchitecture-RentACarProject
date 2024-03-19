using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Models;
using Application.Features.Cars.Queries.GetAll;
using Application.Features.Cars.Queries.GetAllDynamic;
using Application.Features.Cars.Queries.GetAllPagination;
using Application.Features.Cars.Queries.GetById;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Add([FromBody] CreateCarCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCarCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCarCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Created("", await Mediator.Send(new GetAllCarQuery()));
        }

        [HttpGet("GetAllPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery] PageRequest pageRequest)
        {
            GetAllPaginationCarQuery query = new() { PageRequest = pageRequest };
            CarListModel result = await Mediator.Send(query);
            return Created("", result);
        }

        [HttpPost("GetAllDynamic")]
        public async Task<IActionResult> GetAllDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetAllDynamicCarQuery query = new() { PageRequest = pageRequest, Dynamic = dynamic };
            CarListModel result = await Mediator.Send(query);
            return Created("", result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> Add([FromRoute] Guid id)
        {
            return Created("", await Mediator.Send(new GetByIdCarQuery { Id = id }));
        }
    }
}
