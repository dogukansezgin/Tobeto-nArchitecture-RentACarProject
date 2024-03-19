using Application.Features.Models.Models;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Models.Queries.GetAllPagination;

public class GetAllPaginationModelQuery : IRequest<ModelListModel>
{
    public PageRequest PageRequest { get; set; }
}
