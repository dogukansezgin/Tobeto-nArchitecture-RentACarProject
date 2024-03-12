using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdateBrandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly BrandBusinessRules _brandBusinessRules;

    public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<UpdateBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        await _brandBusinessRules.BrandShouldBeExist(request.Id);
        Brand brand = await _brandRepository.GetAsync(x => x.Id == request.Id);

        brand = _brandBusinessRules.UpdateBrand(brand, request);
        await _brandRepository.UpdateAsync(brand);

        UpdateBrandResponse response = _mapper.Map<UpdateBrandResponse>(brand);
        return response;
    }
}
