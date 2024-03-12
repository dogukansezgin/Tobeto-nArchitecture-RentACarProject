using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Dtos;

public class UpdateBrandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime UpdatedDate { get; set; }
}
