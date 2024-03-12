using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetAll;

public class GetAllBrandCommand : IRequest<List<GetListBrandResponse>>
{

    public class GetAllBrandCommandHandler : IRequestHandler<GetAllBrandCommand, List<GetListBrandResponse>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetAllBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListBrandResponse>> Handle(GetAllBrandCommand request, CancellationToken cancellationToken)
        {
            List<Brand> brands = await _brandRepository.GetAllAsync();
            List<GetListBrandResponse> getListBrandResponses = _mapper.Map<List<GetListBrandResponse>>(brands);
            return getListBrandResponses;
        }
    }
}
