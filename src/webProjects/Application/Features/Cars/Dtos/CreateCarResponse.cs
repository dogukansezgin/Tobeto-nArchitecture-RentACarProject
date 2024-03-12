namespace Application.Features.Cars.Dtos;

public class CreateCarResponse
{
    public Guid ModelId { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }
    public double DailyPrice { get; set; }
    public DateTime CreatedDate { get; set; }
}
