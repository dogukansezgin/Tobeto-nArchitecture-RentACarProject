using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Dtos;
using Application.Features.Cars.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Cars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Car, CreateCarCommand>().ReverseMap();
        CreateMap<Car, CreateCarResponse>().ReverseMap();

        CreateMap<Car, DeleteCarCommand>().ReverseMap();
        CreateMap<Car, DeleteCarResponse>().ReverseMap();

        CreateMap<Car, UpdateCarCommand>().ReverseMap();
        CreateMap<Car, UpdateCarResponse>().ReverseMap();

        CreateMap<Car, GetListCarResponse>().ReverseMap();

        CreateMap<Car, GetByIdCarQuery>().ReverseMap();

    }
}
