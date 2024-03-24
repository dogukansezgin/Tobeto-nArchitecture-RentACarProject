using Application.Features.CarImages.Dtos;
using Application.Features.CarImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Utilities.Helpers;
using Domain.Entities;
using MediatR;

namespace Application.Features.CarImages.Commands.Create;

public class CreateCarImageCommandHangler : IRequestHandler<CreateCarImageCommand, CreatedCarImageResponse>
{
    private readonly ICarImageRepository _carImageRepository;
    private readonly IMapper _mapper;
    private readonly CarImageBusinessRules _carImageBusinessRules;

    public CreateCarImageCommandHangler(ICarImageRepository carImageRepository, IMapper mapper, CarImageBusinessRules carImageBusinessRules)
    {
        _carImageRepository = carImageRepository;
        _mapper = mapper;
        _carImageBusinessRules = carImageBusinessRules;
    }

    public async Task<CreatedCarImageResponse> Handle(CreateCarImageCommand request, CancellationToken cancellationToken)
    {
        await _carImageBusinessRules.CheckIfCarExist(request.CarId);
        await _carImageBusinessRules.CheckIfCarImageFormat(request.File);
        await _carImageBusinessRules.CheckIfImageLimit(request.CarId);

        CarImage carImage = new() { CarId = request.CarId };
        carImage.ImagePath = FileHelper.Add(request.File, "CarImages");
        await _carImageRepository.AddAsync(carImage);
        CreatedCarImageResponse response = _mapper.Map<CreatedCarImageResponse>(carImage);
        return response;
    }
}
