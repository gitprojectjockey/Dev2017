using BasicAutoMapping.Entities;
using AutoMapper;

namespace BasicAutoMapping.DTO
{
    public class AddressDisplayOnlyDto : Profile
    {
         // Map from entity to dto single field
        public AddressDisplayOnlyDto()
        {
            CreateMap<AddressEntity, AddressDisplayOnlyDto>()
                .ForMember(dest => dest.CompleteAddress,
                 opts => opts.MapFrom(
                     src => $@"Street: {src.Street}" +
                                $" City: {src.City}" +
                                $" State: {src.State}" +
                                $" Zip: {src.Zip}"));
        }

        public string CompleteAddress { get; set; }

    }
}
