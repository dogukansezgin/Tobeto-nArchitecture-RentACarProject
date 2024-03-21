using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services.CarImageService;

public class CarImageBusinessRules : BaseBusinessRules
{
    private readonly ICarImageRepository _carImageRepository;

    public CarImageBusinessRules(ICarImageRepository carImageRepository)
    {
        _carImageRepository = carImageRepository;
    }

    public async Task<List<CarImage>> CheckIfCarImageNull(Guid carId)
    {
        try
        {
            string path = @"\Images\default.jpg";
            var result = _carImageRepository.GetAllAsync(predicate: x => x.CarId == carId);
            if (result == null)
            {
                List<CarImage> carImages = new List<CarImage>();
                carImages.Add(new CarImage { CarId = carId, ImagePath = path });
            }
        }
        catch (Exception e)
        {
            throw new BusinessException(e.Message);
        }
        return await _carImageRepository.GetAllAsync(x => x.CarId == carId);
    }

    public Task CheckIfImageLimit(Guid carId, Task<List<CarImage>> carImages)
    {
        var carImageCount = carImages.Result.Count();
        if(carImageCount >= 5)
        {
            throw new BusinessException("You exceeded the limit");
        }
        return Task.CompletedTask;
    }

    public Task CheckIfCarImageFormat(IFormFile formFile)
    {
        string fileExtension = Path.GetExtension(formFile.FileName).ToLower();
        if (fileExtension != ".jpg" && fileExtension != "jpeg" && fileExtension != "png")
        {
            throw new BusinessException("Cant add this file format.");
        }
        return Task.CompletedTask;
    }

    public async Task CarImageIdShouldExistsWhenSelected(Guid id)
    {
        CarImage? result = await _carImageRepository.GetAsync(x => x.Id == id);
        if (result is null) throw new BusinessException("Image not exists.");
    }

    public async Task CarImageCarIdShouldExistsWhenSelected(Guid carId)
    {
        CarImage? result = await _carImageRepository.GetAsync(x => x.CarId == carId);
        if (result is null) throw new BusinessException("CarId not exists.");
    }

    public Task CheckForAdd(IFormFile file, Guid carId)
    {
        var carImages = _carImageRepository.GetAllAsync(predicate: x => x.CarId == carId);

        CheckIfCarImageNull(carId);
        CheckIfImageLimit(carId, carImages);
        CheckIfCarImageFormat(file);
        return Task.CompletedTask;
    }
}
