﻿using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Model : BaseEntity<Guid>
{
    public Guid BrandId { get; set; }
    public string Name { get; set; }

    public virtual Brand? Brand { get; set; }
    public virtual ICollection<Car> Cars { get; set; }

    public Model()
    {
        Cars = new HashSet<Car>();
    }

    public Model(Guid id, Guid brandId, string name) : this()
    {
        Id = id;
        BrandId = brandId;
        Name = name;
    }
}
