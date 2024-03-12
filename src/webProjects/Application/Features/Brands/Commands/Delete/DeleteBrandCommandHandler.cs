using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly BrandBusinessRules _brandBusinessRules;

    public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        await _brandBusinessRules.BrandShouldBeExist(request.Id);

        Brand deletedBrand = await _brandRepository.GetAsync(x => x.Id == request.Id);
        await _brandRepository.DeleteAsync(deletedBrand);
        DeletedBrandResponse deletedBrandResponse = _mapper.Map<DeletedBrandResponse>(deletedBrand);
        return deletedBrandResponse;
    }
}
