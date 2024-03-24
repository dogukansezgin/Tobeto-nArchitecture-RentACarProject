using Application.Features.CarImages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarImages.Queries.GetByImageName;

public class GetByImageNameQuery : IRequest<GetListCarImageResponse>
{
    public string ImageName { get; set; }
}
