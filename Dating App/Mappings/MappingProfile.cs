using AutoMapper;
using Dating_App.DTOs;
using Dating_App.Helpers;
using Dating_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_App.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Map from User Object to UserForListDTO Object
            CreateMap<User, UserForListDTO>()
                .ForMember(
                dest => dest.PhotoUrl,
                opt => { opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                }).ForMember(dest => dest.Age,opt=>
                {
                    opt.MapFrom((user, userDTO) => user.DateOfBirth.CalculateAge());
                });
                    
            CreateMap<User, UserForDetailDTO>().ForMember(
                dest => dest.PhotoUrl,
                opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                }).ForMember(dest => dest.Age, opt =>
                {
                    opt.MapFrom((user, userDTO) => user.DateOfBirth.CalculateAge());
                }); ;
            CreateMap<Photo, PhotoForDetailDTO>();
        }
    }
}
