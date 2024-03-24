using Application.Features.CarImages.Commands.Create;
using Application.Features.CarImages.Commands.Delete;
using Application.Features.CarImages.Commands.Update;
using Application.Features.CarImages.Queries.GetAll;
using Application.Features.CarImages.Queries.GetByCarId;
using Application.Features.CarImages.Queries.GetById;
using Application.Features.CarImages.Queries.GetByImageName;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateCarImageCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteCarImageCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateCarImageCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Created("", await Mediator.Send(new GetAllCarImageQuery()));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById([FromQuery] GetByIdCarImageQuery command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpPost("GetByCarId")]
        public async Task<IActionResult> GetByCarId([FromQuery] GetByCarIdCarImageQuery command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpPost("GetByImageName")]
        public async Task<IActionResult> GetByImageName([FromQuery] GetByImageNameQuery command)
        {
            return Created("", await Mediator.Send(command));
        }
    }
}
