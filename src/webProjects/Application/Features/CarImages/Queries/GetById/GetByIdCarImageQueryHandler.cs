using Application.Features.CarImages.Dtos;
using Application.Features.CarImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CarImages.Queries.GetById;

public class GetByIdCarImageQueryHandler : IRequestHandler<GetByIdCarImageQuery, GetListCarImageResponse>
{
    private readonly ICarImageRepository _carImageRepository;
    private readonly IMapper _mapper;
    private readonly CarImageBusinessRules _carImageBusinessRules;

    public GetByIdCarImageQueryHandler(ICarImageRepository carImageRepository, IMapper mapper, CarImageBusinessRules carImageBusinessRules)
    {
        _carImageRepository = carImageRepository;
        _mapper = mapper;
        _carImageBusinessRules = carImageBusinessRules;
    }

    public async Task<GetListCarImageResponse> Handle(GetByIdCarImageQuery request, CancellationToken cancellationToken)
    {
        await _carImageBusinessRules.CarImageIdShouldExistsWhenSelected(request.Id);

        CarImage carImage = await _carImageRepository.GetAsync(x => x.Id == request.Id);
        GetListCarImageResponse response = _mapper.Map<GetListCarImageResponse>(carImage);
        return response;
    }
}
