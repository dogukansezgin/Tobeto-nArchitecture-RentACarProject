using Application.Features.CarImages.Dtos;
using Application.Features.CarImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Utilities.Helpers;
using Domain.Entities;
using MediatR;

namespace Application.Features.CarImages.Commands.Delete;

public class DeleteCarImageCommandHandler : IRequestHandler<DeleteCarImageCommand, DeletedCarImageResponse>
{
    private readonly ICarImageRepository _carImageRepository;
    private readonly IMapper _mapper;
    private readonly CarImageBusinessRules _carImageBusinessRules;

    public DeleteCarImageCommandHandler(ICarImageRepository carImageRepository, IMapper mapper, CarImageBusinessRules carImageBusinessRules)
    {
        _carImageRepository = carImageRepository;
        _mapper = mapper;
        _carImageBusinessRules = carImageBusinessRules;
    }

    public async Task<DeletedCarImageResponse> Handle(DeleteCarImageCommand request, CancellationToken cancellationToken)
    {
        await _carImageBusinessRules.CarImageIdShouldExistsWhenSelected(request.Id);

        CarImage carImage = await _carImageRepository.GetAsync(x => x.Id == request.Id);
        var path = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot") + carImage.ImagePath;
        await _carImageRepository.DeleteAsync(carImage, request.IsPermament);
        if (request.IsPermament) FileHelper.Delete(path);

        DeletedCarImageResponse deletedCarImageResponse = _mapper.Map<DeletedCarImageResponse>(carImage);
        return deletedCarImageResponse;
    }
}
