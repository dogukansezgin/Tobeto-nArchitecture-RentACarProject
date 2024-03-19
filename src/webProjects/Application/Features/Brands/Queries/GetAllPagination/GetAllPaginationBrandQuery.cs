using Application.Features.Brands.Models;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Brands.Queries.GetAllPagination;

public class GetAllPaginationBrandQuery : IRequest<BrandListModel>
{
    public PageRequest PageRequest { get; set; }
}
