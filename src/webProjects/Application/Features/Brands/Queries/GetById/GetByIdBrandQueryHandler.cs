﻿using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetById;

public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, GetListBrandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly BrandBusinessRules _brandBusinessRules;

    public GetByIdBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<GetListBrandResponse> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
    {
        await _brandBusinessRules.BrandShouldBeExist(request.Id);

        Brand brand = await _brandRepository.GetAsync(x => x.Id == request.Id);
        GetListBrandResponse getByIdBrandResponse = _mapper.Map<GetListBrandResponse>(brand);
        return getByIdBrandResponse;
    }
}
