using Application.Features.Models.Commands.Update;
using Application.Services.Repositories;
using Core.Application.Rules;
using Domain.Entities;

namespace Application.Features.Models.Rules;

public class ModelBusinessRules: BaseBusinessRules
{
    private readonly IModelRepository _modelRepository;

    public ModelBusinessRules(IModelRepository modelRepository)
    {
        _modelRepository = modelRepository;
    }

    public async Task ModelNameShouldNotExist(string name)
    {
        var isExist = await _modelRepository.GetAsync(x => x.Name.Trim() == name.Trim()) is not null;
        if (isExist) throw new Exception("Model already exist.");
    }

    public async Task ModelShouldBeExist(Guid id)
    {
        var isExist = await _modelRepository.GetAsync(x => x.Id == id) is null;
        if (isExist) throw new Exception("Model is not exist.");
    }

    public Model UpdateModel(Model model, UpdateModelCommand request)
    {
        var brandId = request.BrandId.ToString();
        model.BrandId = brandId != "string" || request.BrandId != null ? request.BrandId : model.BrandId;
        model.Name = request.Name != "string" || request.Name != null ? request.Name : model.Name;

        model.UpdatedDate = DateTime.UtcNow;
        return model;
    }
}
