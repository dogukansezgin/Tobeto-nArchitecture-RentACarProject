using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetAllPagination;

public class GetAllPaginationModelQueryHandler : IRequestHandler<GetAllPaginationModelQuery, ModelListModel>
{
    private readonly IModelRepository _modelRepository; 
    private readonly IMapper _mapper;

    public GetAllPaginationModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<ModelListModel> Handle(GetAllPaginationModelQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Model> models = await _modelRepository.GetListPaginateAsync
            (index: request.PageRequest.Page, size: request.PageRequest.PageSize, include: x => x.Include(x => x.Brand));

        ModelListModel modelListModel = _mapper.Map<ModelListModel>(models);
        return modelListModel;
    }
}
