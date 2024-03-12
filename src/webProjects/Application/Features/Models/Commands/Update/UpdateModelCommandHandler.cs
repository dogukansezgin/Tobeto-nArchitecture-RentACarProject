using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Update;

public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, UpdateModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    private readonly ModelBusinessRules _modelBusinessRules;

    public UpdateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
        _modelBusinessRules = modelBusinessRules;
    }

    public async Task<UpdateModelResponse> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        await _modelBusinessRules.ModelShouldBeExist(request.Id);
        Model model = await _modelRepository.GetAsync(x => x.Id == request.Id);

        model = _modelBusinessRules.UpdateModel(model, request);
        await _modelRepository.UpdateAsync(model);

        UpdateModelResponse response = _mapper.Map<UpdateModelResponse>(model);
        return response;
    }
}
