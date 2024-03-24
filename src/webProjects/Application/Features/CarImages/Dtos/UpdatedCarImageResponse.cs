namespace Application.Features.CarImages.Dtos;

public class UpdatedCarImageResponse
{
    public Guid Id { get; set; }
    public Guid CarId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}


