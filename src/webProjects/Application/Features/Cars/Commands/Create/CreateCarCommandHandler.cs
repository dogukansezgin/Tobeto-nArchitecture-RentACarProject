using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreateCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;
    private readonly CarBusinessRules _carBusinessRules;

    public CreateCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
    {
        _carRepository = carRepository;
        _mapper = mapper;
        _carBusinessRules = carBusinessRules;
    }

    public async Task<CreateCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        await _carBusinessRules.CarPlateShouldNotExist(request.Plate);

        Car car = _mapper.Map<Car>(request);
        await _carRepository.AddAsync(car);
        CreateCarResponse response = _mapper.Map<CreateCarResponse>(car);
        return response;
    }
}
