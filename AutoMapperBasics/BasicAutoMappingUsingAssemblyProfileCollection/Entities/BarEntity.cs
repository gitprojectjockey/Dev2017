using AutoMapper;
using BasicAutoMapping.DTO;

namespace BasicAutoMapping.Entities
{
    public class BarEntity : Profile
    {
        //DTO to Entity Map
        public BarEntity()
        {
            CreateMap<BarDto, BarEntity>()
                .ForMember(dest => dest.PersonFirstName,
                opts => opts.MapFrom(src => src.PersonFName))
                .ForMember(dest => dest.PersonLastName,
                opts => opts.MapFrom(src => src.PersonLName));
        }

        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
    }
}
