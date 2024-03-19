using Application.Features.Models.Dtos;
using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetAll;

public class GetAllModelQuery : IRequest<List<GetListModelResponse>>, ICachableRequest
{
    public bool BypassCache { get; }

    public string CacheKey => "model-list";

    public TimeSpan? SlidingExpiration { get; }

    public class GetAllModelQueryHandler : IRequestHandler<GetAllModelQuery, List<GetListModelResponse>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetAllModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListModelResponse>> Handle(GetAllModelQuery request, CancellationToken cancellationToken)
        {
            List<Model> models = await _modelRepository.GetAllAsync(include: x => x.Include(x => x.Brand));
            List<GetListModelResponse> getListModelResponses = _mapper.Map<List<GetListModelResponse>>(models);
            return getListModelResponses;
        }
    }
}
