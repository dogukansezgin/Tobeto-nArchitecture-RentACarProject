namespace Application.Features.Models.Dtos;

public class GetListModelResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid BrandId { get; set; }
    public string BrandName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
