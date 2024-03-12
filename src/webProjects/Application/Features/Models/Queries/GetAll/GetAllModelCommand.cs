using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetAll;

public class GetAllModelCommand : IRequest<List<GetListModelResponse>>
{

    public class GetAllModelCommandHandler : IRequestHandler<GetAllModelCommand, List<GetListModelResponse>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        private readonly ModelBusinessRules _modelBusinessRules;

        public GetAllModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _modelBusinessRules = modelBusinessRules;
        }

        public async Task<List<GetListModelResponse>> Handle(GetAllModelCommand request, CancellationToken cancellationToken)
        {
            List<Model> models = await _modelRepository.GetAllAsync(include: x => x.Include(x => x.Brand));
            List<GetListModelResponse> getListModelResponses = _mapper.Map<List<GetListModelResponse>>(models);
            return getListModelResponses;
        }
    }
}
