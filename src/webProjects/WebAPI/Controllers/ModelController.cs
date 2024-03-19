using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetAll;
using Application.Features.Models.Queries.GetAllDynamic;
using Application.Features.Models.Queries.GetAllPagination;
using Application.Features.Models.Queries.GetById;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Add([FromBody] CreateModelCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteModelCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateModelCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Created("", await Mediator.Send(new GetAllModelQuery()));
        }

        [HttpGet("GetAllPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery] PageRequest pageRequest)
        {
            GetAllPaginationModelQuery query = new() { PageRequest = pageRequest };
            ModelListModel result = await Mediator.Send(query);
            return Created("", result);
        }

        [HttpPost("GetAllDynamic")]
        public async Task<IActionResult> GetAllDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetAllDynamicModelQuery query = new() { PageRequest = pageRequest, Dynamic = dynamic };
            ModelListModel result = await Mediator.Send(query);
            return Created("", result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Created("", await Mediator.Send(new GetByIdModelQuery { Id = id }));
        }
    }
}
