using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using MediatR;

namespace Application.Features.Models.Commands.Update;

public class UpdateModelCommand : IRequest<UpdateModelResponse>, IIntervalRequest, ILoggableRequest, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string Name { get; set; }

    public int Interval => 1;

    public bool BypassCache { get; }

    public string CacheKey => "model-list";
}
