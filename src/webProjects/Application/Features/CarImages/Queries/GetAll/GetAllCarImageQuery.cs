using Application.Features.CarImages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CarImages.Queries.GetAll;

public class GetAllCarImageQuery : IRequest<List<GetListCarImageResponse>>
{

    public class GetAllCarImageQueryHandler : IRequestHandler<GetAllCarImageQuery, List<GetListCarImageResponse>>
    {
        private readonly ICarImageRepository _carImageRepository;
        private readonly IMapper _mapper;

        public GetAllCarImageQueryHandler(ICarImageRepository carImageRepository, IMapper mapper)
        {
            _carImageRepository = carImageRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListCarImageResponse>> Handle(GetAllCarImageQuery request, CancellationToken cancellationToken)
        {
            List<CarImage> carImages = await _carImageRepository.GetAllAsync();
            List<GetListCarImageResponse> response = _mapper.Map<List<GetListCarImageResponse>>(carImages);
            return response;
        }
    }
}
