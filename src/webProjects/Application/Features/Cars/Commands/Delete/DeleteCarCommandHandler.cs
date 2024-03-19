using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Commands.Delete;

public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeleteCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;
    private readonly CarBusinessRules _carBusinessRules;

    public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
    {
        _carRepository = carRepository;
        _mapper = mapper;
        _carBusinessRules = carBusinessRules;
    }

    public async Task<DeleteCarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        await _carBusinessRules.CarShouldBeExist(request.Id);

        Car deletedCar = await _carRepository.GetAsync(x => x.Id == request.Id);
        await _carRepository.DeleteAsync(deletedCar, request.IsPermament);
        DeleteCarResponse deleteCarResponse = _mapper.Map<DeleteCarResponse>(deletedCar);
        return deleteCarResponse;
    }
}
