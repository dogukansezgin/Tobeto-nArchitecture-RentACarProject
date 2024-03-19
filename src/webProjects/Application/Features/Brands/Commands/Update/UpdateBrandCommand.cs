using Application.Features.Brands.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommand : IRequest<UpdateBrandResponse>, IIntervalRequest, ILoggableRequest, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public int Interval => 1;

    public bool BypassCache { get; }

    public string CacheKey => "brand-list";

}
