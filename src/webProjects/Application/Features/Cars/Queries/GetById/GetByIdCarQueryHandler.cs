using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery, GetListCarResponse>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;
    private readonly CarBusinessRules _carBusinessRules;

    public GetByIdCarQueryHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
    {
        _carRepository = carRepository;
        _mapper = mapper;
        _carBusinessRules = carBusinessRules;
    }

    public async Task<GetListCarResponse> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
    {
        await _carBusinessRules.CarShouldBeExist(request.Id);

        Car car = await _carRepository.GetAsync(x => x.Id == request.Id, include: x => x.Include(x => x.Model));
        GetListCarResponse getListCarResponse = _mapper.Map<GetListCarResponse>(car);
        return getListCarResponse;
    }
}
