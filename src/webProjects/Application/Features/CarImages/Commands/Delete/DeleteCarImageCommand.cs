using Application.Features.CarImages.Dtos;
using MediatR;

namespace Application.Features.CarImages.Commands.Delete;

public class DeleteCarImageCommand : IRequest<DeletedCarImageResponse>
{
    public Guid Id { get; set; }
    public bool IsPermament { get; set; }
}
