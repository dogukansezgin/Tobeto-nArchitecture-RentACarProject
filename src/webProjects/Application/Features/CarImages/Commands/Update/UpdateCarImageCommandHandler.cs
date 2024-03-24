using Application.Features.CarImages.Dtos;
using Application.Features.CarImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Utilities.Helpers;
using Domain.Entities;
using MediatR;

namespace Application.Features.CarImages.Commands.Update;

public class UpdateCarImageCommandHandler : IRequestHandler<UpdateCarImageCommand, UpdatedCarImageResponse>
{
    private readonly ICarImageRepository _carImageRepository;
    private readonly IMapper _mapper;
    private readonly CarImageBusinessRules _carImageBusinessRules;

    public UpdateCarImageCommandHandler(ICarImageRepository carImageRepository, IMapper mapper, CarImageBusinessRules carImageBusinessRules)
    {
        _carImageRepository = carImageRepository;
        _mapper = mapper;
        _carImageBusinessRules = carImageBusinessRules;
    }

    public async Task<UpdatedCarImageResponse> Handle(UpdateCarImageCommand request, CancellationToken cancellationToken)
    {
        await _carImageBusinessRules.CarImageIdShouldExistsWhenSelected(request.Id);
        await _carImageBusinessRules.CheckIfCarImageFormat(request.File);

        CarImage carImage = await _carImageRepository.GetAsync(x => x.Id == request.Id);
        var path = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot") + carImage.ImagePath;
        carImage.ImagePath = FileHelper.Update(path, request.File, "CarImages");
        await _carImageRepository.UpdateAsync(carImage);

        UpdatedCarImageResponse updatedCarImageResponse = _mapper.Map<UpdatedCarImageResponse>(carImage);
        return updatedCarImageResponse;
    }
}
