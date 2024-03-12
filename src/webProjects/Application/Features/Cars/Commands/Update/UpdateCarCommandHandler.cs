using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands.Update;

public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, UpdateCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;
    private readonly CarBusinessRules _carBusinessRules;

    public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
    {
        _carRepository = carRepository;
        _mapper = mapper;
        _carBusinessRules = carBusinessRules;
    }

    public async Task<UpdateCarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        await _carBusinessRules.CarShouldBeExist(request.Id);
        Car car = await _carRepository.GetAsync(x => x.Id == request.Id);

        car = _carBusinessRules.UpdateCar(car, request);
        await _carRepository.UpdateAsync(car);

        UpdateCarResponse updateCarResponse = _mapper.Map<UpdateCarResponse>(car);
        return updateCarResponse;
    }
}
