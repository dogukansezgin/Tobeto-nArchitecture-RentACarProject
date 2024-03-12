using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetById;

public class GetByIdModelCommandHandler : IRequestHandler<GetByIdModelCommand, GetListModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    private readonly ModelBusinessRules _modelBusinessRules;

    public GetByIdModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
        _modelBusinessRules = modelBusinessRules;
    }

    public async Task<GetListModelResponse> Handle(GetByIdModelCommand request, CancellationToken cancellationToken)
    {
        await _modelBusinessRules.ModelShouldBeExist(request.Id);

        Model model = await _modelRepository.GetAsync(x => x.Id == request.Id, include: x => x.Include(x => x.Brand));
        GetListModelResponse response = _mapper.Map<GetListModelResponse>(model);
        return response;
    }
}
