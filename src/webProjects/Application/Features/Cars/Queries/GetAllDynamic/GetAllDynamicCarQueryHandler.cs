﻿using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries.GetAllDynamic;

public class GetAllDynamicCarQueryHandler : IRequestHandler<GetAllDynamicCarQuery, CarListModel>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetAllDynamicCarQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CarListModel> Handle(GetAllDynamicCarQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Car> cars = await _carRepository.GetListByDynamicAsync
            (dynamic: request.Dynamic, index: request.PageRequest.Page, size: request.PageRequest.PageSize);

        CarListModel carListModel = _mapper.Map<CarListModel>(cars);
        return carListModel;
    }
}
