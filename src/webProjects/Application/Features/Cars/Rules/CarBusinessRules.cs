using Application.Features.Brands.Commands.Update;
using Application.Features.Cars.Commands.Update;
using Application.Services.Repositories;
using Core.Application.Rules;
using Domain.Entities;

namespace Application.Features.Cars.Rules;

public class CarBusinessRules : BaseBusinessRules
{
    private readonly ICarRepository _carRepository;

    public CarBusinessRules(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task CarPlateShouldNotExist(string plate)
    {
        var isExist = await _carRepository.GetAsync(x => x.Plate == plate) is not null;
        if (isExist) throw new Exception("This Car Plate already exist");
    }

    public async Task CarShouldBeExist(Guid id)
    {
        var isExist = await _carRepository.GetAsync(x => x.Id == id) is null;
        if (isExist) throw new Exception("Car is not exist.");
    }

    public Car UpdateCar(Car car, UpdateCarCommand request)
    {
        car.Plate = request.Plate != "string" || request.Plate != null ? request.Plate : car.Plate;

        car.UpdatedDate = DateTime.UtcNow;
        return car;
    }
}
