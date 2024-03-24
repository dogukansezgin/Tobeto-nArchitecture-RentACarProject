using Application.Features.CarImages.Commands.Create;
using Application.Features.CarImages.Commands.Delete;
using Application.Features.CarImages.Commands.Update;
using Application.Features.CarImages.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.CarImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CarImage, CreateCarImageCommand>().ReverseMap();
        CreateMap<CarImage, CreatedCarImageResponse>().ReverseMap();

        CreateMap<CarImage, DeleteCarImageCommand>().ReverseMap();
        CreateMap<CarImage, DeletedCarImageResponse>().ReverseMap();

        CreateMap<CarImage, UpdateCarImageCommand>().ReverseMap();
        CreateMap<CarImage, UpdatedCarImageResponse>().ReverseMap();

        CreateMap<CarImage, GetListCarImageResponse>().ReverseMap();


    }
}
