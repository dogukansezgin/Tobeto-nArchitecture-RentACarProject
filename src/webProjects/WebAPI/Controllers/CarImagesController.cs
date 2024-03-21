using Application.Services.CarImageService;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : BaseController
    {
        private readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(IFormFile file, [FromForm] Guid carId)
        {
            var result = await _carImageService.Add(file, carId);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var carImage = await _carImageService.Get(id);
            var result = await _carImageService.Delete(carImage);
            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(IFormFile file, [FromRoute] Guid id)
        {
            var carImage = await _carImageService.Get(id);
            var result = await _carImageService.Update(file, carImage);
            return Ok(result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carImageService.GetList();
            return Ok(result);
        }

        [HttpGet("GetImages/{carId}")]
        public async Task<IActionResult> GetImagesByCarId(Guid carId)
        {
            var result = await _carImageService.GetImagesByCarId(carId);
            return Ok(result);
        }
    }
}
