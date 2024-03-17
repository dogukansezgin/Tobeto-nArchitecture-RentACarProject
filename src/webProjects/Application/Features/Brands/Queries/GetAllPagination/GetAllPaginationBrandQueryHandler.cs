using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetAllPagination;

public class GetAllPaginationBrandQueryHandler : IRequestHandler<GetAllPaginationBrandQuery, BrandListModel>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetAllPaginationBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<BrandListModel> Handle(GetAllPaginationBrandQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Brand> brands = await _brandRepository.GetListPaginateAsync
            (index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        BrandListModel brandListModel = _mapper.Map<BrandListModel>(brands);
        return brandListModel;
    }
}
