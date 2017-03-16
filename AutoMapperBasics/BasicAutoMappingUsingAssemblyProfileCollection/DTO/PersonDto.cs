using BasicAutoMapping.DTO;
using BasicAutoMapping.Entities;

namespace BasicAutoMapping.DTO
{
    public class PersonDto : AutoMapper.Profile
    {
        //flatten out from Person entity and personentity.address to personDto
        public PersonDto()
        {
            CreateMap<PersonEntity, PersonDto>()
                .ForMember(dest => dest.FName, opts => opts.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LName, opts => opts.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Street, opts => opts.MapFrom(src => src.PersonAddress.Street))
                .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.PersonAddress.City))
                .ForMember(dest => dest.State, opts => opts.MapFrom(src => src.PersonAddress.State))
                .ForMember(dest => dest.ZipCode, opts => opts.MapFrom(src => src.PersonAddress.Zip));
        }

        public string FName { get; set; }
        public string LName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
