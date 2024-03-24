using Application.Features.CarImages.Dtos;
using Application.Features.CarImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CarImages.Queries.GetByCarId;

public class GetByCarIdCarImagesQueryHandler : IRequestHandler<GetByCarIdCarImageQuery, List<GetListCarImageResponse>>
{
    private readonly ICarImageRepository _carImageRepository;
    private readonly IMapper _mapper;
    private readonly CarImageBusinessRules _carImageBusinessRules;

    public GetByCarIdCarImagesQueryHandler(ICarImageRepository carImageRepository, IMapper mapper, CarImageBusinessRules carImageBusinessRules)
    {
        _carImageRepository = carImageRepository;
        _mapper = mapper;
        _carImageBusinessRules = carImageBusinessRules;
    }

    public async Task<List<GetListCarImageResponse>> Handle(GetByCarIdCarImageQuery request, CancellationToken cancellationToken)
    {
        await _carImageBusinessRules.CarImageCarIdShouldExistsWhenSelected(request.CarId);

        List<CarImage> carImages = await _carImageRepository.GetAllAsync(predicate: x => x.CarId == request.CarId);
        List<GetListCarImageResponse> response = _mapper.Map<List<GetListCarImageResponse>>(carImages);
        return response;
    }
}
