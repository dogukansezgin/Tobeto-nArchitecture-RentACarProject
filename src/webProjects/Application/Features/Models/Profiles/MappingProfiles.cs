using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Dtos;
using Application.Features.Models.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, CreateModelCommand>().ReverseMap();
        CreateMap<Model, CreateModelResponse>().ReverseMap();

        CreateMap<Model, DeleteModelCommand>().ReverseMap();
        CreateMap<Model, DeleteModelResponse>().ReverseMap();

        CreateMap<Model, UpdateModelCommand>().ReverseMap();
        CreateMap<Model, UpdateModelResponse>().ReverseMap();

        CreateMap<Model, GetListModelResponse>().ReverseMap();

        CreateMap<Model, GetByIdModelQuery>().ReverseMap();

    }
}
