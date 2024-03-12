namespace Application.Features.Models.Dtos;

public class UpdateModelResponse
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public string Name { get; set; }
    public DateTime UpdatedDate { get; set; }
}
