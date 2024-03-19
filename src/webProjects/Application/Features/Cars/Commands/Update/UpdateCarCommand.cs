using Application.Features.Cars.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using MediatR;

namespace Application.Features.Cars.Commands.Update;

public class UpdateCarCommand : IRequest<UpdateCarResponse>, IIntervalRequest, ILoggableRequest, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public Guid ModelId { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }
    public double DailyPrice { get; set; }

    public int Interval => 1;

    public bool BypassCache { get; }

    public string CacheKey => "car-list";
}
