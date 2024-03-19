using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetAll;

public class GetAllBrandQuery : IRequest<List<GetListBrandResponse>>, ICachableRequest
{
    public bool BypassCache { get; }

    public string CacheKey => "brand-list";

    public TimeSpan? SlidingExpiration { get; }

    public class GetAllBrandCommandQuery : IRequestHandler<GetAllBrandQuery, List<GetListBrandResponse>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetAllBrandCommandQuery(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListBrandResponse>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            List<Brand> brands = await _brandRepository.GetAllAsync();
            List<GetListBrandResponse> getListBrandResponses = _mapper.Map<List<GetListBrandResponse>>(brands);
            return getListBrandResponses;
        }
    }
}
