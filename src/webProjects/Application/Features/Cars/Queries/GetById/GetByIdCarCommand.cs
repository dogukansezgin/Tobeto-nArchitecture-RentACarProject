using Application.Features.Cars.Dtos;
using MediatR;

namespace Application.Features.Cars.Queries.GetById;

public class GetByIdCarCommand : IRequest<GetListCarResponse>
{
    public Guid Id { get; set; }
}
