using Application.Features.Cars.Dtos;
using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetAll;

public class GetAllCarCommand : IRequest<List<GetListCarResponse>>
{

    public class GetAllCarCommandHandler : IRequestHandler<GetAllCarCommand, List<GetListCarResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _carBusinessRules;

        public GetAllCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _carBusinessRules = carBusinessRules;
        }

        public async Task<List<GetListCarResponse>> Handle(GetAllCarCommand request, CancellationToken cancellationToken)
        {
            List<Car> cars = await _carRepository.GetAllAsync(include: x => x.Include(x => x.Model));
            List<GetListCarResponse> getListCarResponses = _mapper.Map<List<GetListCarResponse>>(cars);
            return getListCarResponses;
        }
    }
}
