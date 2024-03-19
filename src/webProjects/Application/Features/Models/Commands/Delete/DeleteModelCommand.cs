using Application.Features.Models.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using MediatR;

namespace Application.Features.Models.Commands.Delete;

public class DeleteModelCommand : IRequest<DeleteModelResponse>, IIntervalRequest, ILoggableRequest, ICacheRemoverRequest
{
    public Guid Id { get; set; }

    public int Interval => 1;

    public bool BypassCache { get; }

    public string CacheKey => "model-list";
}
