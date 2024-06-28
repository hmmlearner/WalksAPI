using AutoMapper;
using NZWalks.API.Models;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDTO, Region>().ReverseMap();
            CreateMap<AddRegionRequestDTO, RegionDTO>().ReverseMap();
            CreateMap<UpdateRegionDTO,Region>().ReverseMap();   

            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDTO>().ReverseMap();
            CreateMap<UpdateWalkRequestDTO, Walk>().ReverseMap();

            CreateMap<Difficulty,DifficultyDTO>().ReverseMap();


        }
    }
}
