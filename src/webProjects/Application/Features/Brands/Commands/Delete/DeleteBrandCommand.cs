using Application.Features.Brands.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using MediatR;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommand : IRequest<DeletedBrandResponse>, IIntervalRequest, ILoggableRequest, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public bool IsPermament { get; set; }

    public int Interval => 1;

    public bool BypassCache { get; }

    public string CacheKey => "brand-list";
}
