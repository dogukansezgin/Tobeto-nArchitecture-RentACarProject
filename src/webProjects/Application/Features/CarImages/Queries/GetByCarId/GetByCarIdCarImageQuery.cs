using Application.Features.CarImages.Dtos;
using MediatR;

namespace Application.Features.CarImages.Queries.GetByCarId;

public class GetByCarIdCarImageQuery : IRequest<List<GetListCarImageResponse>>
{
    public Guid CarId { get; set; }
}
