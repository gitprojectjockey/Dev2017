using AutoMapper;
using BasicAutoMapping.Entities;

namespace BasicAutoMapping.DTO
{
    public class BarDto : Profile
    {
        public BarDto()
        {
            // Map entity to dto
            CreateMap<BarEntity, BarDto>()
                .ForMember(dest => dest.PersonFName,
                opts => opts.MapFrom(src => src.PersonFirstName))
                .ForMember(dest => dest.PersonLName,
                opts => opts.MapFrom(src => src.PersonLastName));
        }
        public string PersonFName { get; set; }
        public string PersonLName { get; set; }
    }
}
