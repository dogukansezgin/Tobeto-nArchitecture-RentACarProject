using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreateModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    private readonly ModelBusinessRules _brandBusinessRules;

    public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules brandBusinessRules)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
        _brandBusinessRules = brandBusinessRules;
    }

    public async Task<CreateModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        await _brandBusinessRules.ModelNameShouldNotExist(request.Name);

        Model model = _mapper.Map<Model>(request);
        await _modelRepository.AddAsync(model);
        CreateModelResponse response = _mapper.Map<CreateModelResponse>(model);
        return response;
    }
}
