using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CarImage : BaseEntity<Guid>
{
    public Guid CarId { get; set; }
    public string ImagePath { get; set; }

    public virtual Car Car { get; set; }

    public CarImage()
    {

    }

    public CarImage(Guid id, Guid carId, string ımagePath) : this()
    {
        Id = id;
        CarId = carId;
        ImagePath = ımagePath;
    }
}
