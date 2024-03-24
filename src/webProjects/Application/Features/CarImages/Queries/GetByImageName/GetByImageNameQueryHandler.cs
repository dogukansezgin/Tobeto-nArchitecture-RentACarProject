using Amazon.Runtime.Internal;
using Application.Features.CarImages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Text.RegularExpressions;

namespace Application.Features.CarImages.Queries.GetByImageName;

public class GetByImageNameQueryHandler : IRequestHandler<GetByImageNameQuery, GetListCarImageResponse>
{
    private readonly ICarImageRepository _carImageRepository; 
    private readonly IMapper _mapper;

    public GetByImageNameQueryHandler(ICarImageRepository carImageRepository, IMapper mapper)
    {
        _carImageRepository = carImageRepository;
        _mapper = mapper;
    }

    public async Task<GetListCarImageResponse> Handle(GetByImageNameQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<CarImage> carImages = await _carImageRepository.GetAllAsync();

        IEnumerable<CarImage> matchingCarImages = carImages.Where(x => Regex.IsMatch(x.ImagePath, Regex.Escape(request.ImageName), RegexOptions.IgnoreCase));

        CarImage carImage = matchingCarImages.FirstOrDefault();

        GetListCarImageResponse response = _mapper.Map<GetListCarImageResponse>(carImage);
        return response;
    }
}
