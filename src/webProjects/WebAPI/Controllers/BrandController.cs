using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetAll;
using Application.Features.Brands.Queries.GetAllDynamic;
using Application.Features.Brands.Queries.GetAllPagination;
using Application.Features.Brands.Queries.GetById;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseController
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Created("", await Mediator.Send(new GetAllBrandQuery()));
        }

        [HttpGet("GetAllPagination")]
        public async Task<IActionResult> GetAllPagination([FromQuery] PageRequest pageRequest)
        {
            GetAllPaginationBrandQuery query = new() { PageRequest = pageRequest };
            BrandListModel result = await Mediator.Send(query);
            return Created("", result);
        }

        [HttpPost("GetAllDynamic")]
        public async Task<IActionResult> GetAllDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetAllDynamicBrandQuery query = new() { PageRequest = pageRequest, Dynamic = dynamic };
            BrandListModel result = await Mediator.Send(query);
            return Created("", result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Created("", await Mediator.Send(new GetByIdBrandQuery { Id = id }));
        }

    }
}
