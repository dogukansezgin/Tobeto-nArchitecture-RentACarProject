using Application.Features.Brands.Commands.Update;
using Application.Services.Repositories;
using Core.Application.Rules;
using Domain.Entities;

namespace Application.Features.Brands.Rules;

public class BrandBusinessRules : BaseBusinessRules
{
    private readonly IBrandRepository _brandRepository;

    public BrandBusinessRules(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task BrandNameShouldNotExist(string name)
    {
        var isExist = await _brandRepository.GetAsync(x => x.Name.Trim() == name.Trim()) is not null;
        if (isExist) throw new Exception("Brand already exist.");
    }

    public async Task BrandShouldBeExist(Guid id)
    {
        var isExist = await _brandRepository.GetAsync(x => x.Id == id) is null;
        if (isExist) throw new Exception("Brand is not exist.");
    }

    public Brand UpdateBrand(Brand brand, UpdateBrandCommand request)
    {
        brand.Name = request.Name != "string" || request.Name != null ? request.Name : brand.Name;

        brand.UpdatedDate = DateTime.UtcNow;
        return brand;
    }
}
