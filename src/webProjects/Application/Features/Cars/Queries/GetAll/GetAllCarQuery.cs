using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetAll;

public class GetAllCarQuery : IRequest<List<GetListCarResponse>>, ICachableRequest
{
    public int Interval => 1;

    public bool BypassCache { get; }

    public string CacheKey => "car-list";

    public TimeSpan? SlidingExpiration { get; }

    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, List<GetListCarResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetAllCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListCarResponse>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            List<Car> cars = await _carRepository.GetAllAsync(include: x => x.Include(x => x.Model).Include(x => x.Model.Brand));
            List<GetListCarResponse> getListCarResponses = _mapper.Map<List<GetListCarResponse>>(cars);
            return getListCarResponses;
        }
    }
}
