using Application.Features.CarImages.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CarImages.Commands.Create;

public class CreateCarImageCommand : IRequest<CreatedCarImageResponse>
{
    public Guid CarId { get; set; }
    public IFormFile File { get; set; }
}
