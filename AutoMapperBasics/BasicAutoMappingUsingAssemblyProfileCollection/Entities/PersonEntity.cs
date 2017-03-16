using AutoMapper;

namespace BasicAutoMapping.Entities
{
    public class PersonEntity : Profile
    {
        //map Person dto back to person entity and personentity.address
        public PersonEntity()
        {
            CreateMap<DTO.PersonDto, PersonEntity>()
                  .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FName))
                  .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LName))
                  .ForMember(dest => dest.PersonAddress, opts => opts.MapFrom(src => new AddressEntity()
                  {
                      Street = src.Street,
                      City = src.City,
                      State = src.State,
                      Zip = src.ZipCode
                  }));
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressEntity PersonAddress { get; set; }
    }
}
