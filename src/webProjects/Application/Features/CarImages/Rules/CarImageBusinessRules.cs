using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CarImages.Rules;

public class CarImageBusinessRules : BaseBusinessRules
{
    private readonly ICarImageRepository _carImageRepository;
    private readonly CarBusinessRules _carBusinessRules;

    public CarImageBusinessRules(ICarImageRepository carImageRepository, CarBusinessRules carBusinessRules)
    {
        _carImageRepository = carImageRepository;
        _carBusinessRules = carBusinessRules;
    }

    public async Task CheckIfCarExist(Guid id)
    {
        await _carBusinessRules.CarShouldBeExist(id);
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

    public Task CheckIfImageLimit(Guid carId)
    {
        var carImageCount = _carImageRepository.GetAllAsync().Result.Count();
        if (carImageCount >= 5)
        {
            throw new BusinessException("You exceeded the limit");
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

    public async Task<List<CarImage>> CheckIfCarImageNull(Guid carId)
    {
        try
        {
            string path = @"\Images\default.jpg";

            var carImages = await _carImageRepository.GetAllAsync(predicate: x => x.CarId == carId);

            if (carImages == null || carImages.Count == 0)
            {
                carImages = new List<CarImage>();
                carImages.Add(new CarImage { CarId = carId, ImagePath = path });

                //await _carImageRepository.AddAsync(new CarImage { CarId = carId, ImagePath = defaultImagePath });

                return carImages;
            }
            return carImages;
        }
        catch (Exception e)
        {
            throw new BusinessException(e.Message);
        }
    }

}
