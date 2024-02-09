using AutoMapper;
using RainfallApi.Models;
using RainfallApi.Models.Dtos;

namespace RainfallApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RainfallReadingDto, RainfallReading>();
            CreateMap<ItemDto, RainfallReadingDetails>();
        }
    }
}
