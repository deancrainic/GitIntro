using AutoMapper;
using HakunaMatata.API.Dto;
using HakunaMatata.Core.Models;

namespace HakunaMatata.API.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageGetDto>()
                .ForMember(i => i.Id, opt => opt.MapFrom(s => s.ImageId))
                .ForMember(i => i.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(i => i.Path, opt => opt.MapFrom(s => s.Path));

            CreateMap<ImageCreateDto, Image>()
                .ForMember(i => i.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(i => i.Path, opt => opt.MapFrom(s => s.Path));
        }
    }
}
