using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Delete;

public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, DeleteModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    private readonly ModelBusinessRules _modelBusinessRules;

    public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
        _modelBusinessRules = modelBusinessRules;
    }

    public async Task<DeleteModelResponse> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        await _modelBusinessRules.ModelShouldBeExist(request.Id);

        Model deletedModel = await _modelRepository.GetAsync(x => x.Id ==  request.Id);
        await _modelRepository.DeleteAsync(deletedModel, request.IsPermament);
        DeleteModelResponse response = _mapper.Map<DeleteModelResponse>(deletedModel);
        return response;
    }
}
