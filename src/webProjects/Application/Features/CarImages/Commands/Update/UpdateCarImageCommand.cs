using Application.Features.CarImages.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CarImages.Commands.Update;

public class UpdateCarImageCommand : IRequest<UpdatedCarImageResponse>
{
    public Guid Id { get; set; }
    public IFormFile File { get; set; }
}
