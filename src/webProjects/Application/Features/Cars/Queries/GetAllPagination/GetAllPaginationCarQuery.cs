using Application.Features.Cars.Dtos;
using Application.Features.Cars.Models;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using MediatR;

namespace Application.Features.Cars.Queries.GetAllPagination;

public class GetAllPaginationCarQuery : IRequest<CarListModel>
{
    public PageRequest PageRequest { get; set; }
}
