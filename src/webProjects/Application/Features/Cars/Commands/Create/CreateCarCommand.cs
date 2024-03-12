using Application.Features.Cars.Dtos;
using MediatR;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommand : IRequest<CreateCarResponse>
{
    public Guid ModelId { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }
    public double DailyPrice { get; set; }
}
