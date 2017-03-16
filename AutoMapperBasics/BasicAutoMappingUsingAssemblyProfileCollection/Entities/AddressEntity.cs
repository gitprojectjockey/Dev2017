
namespace BasicAutoMapping.Entities
{
    public class AddressEntity : AutoMapper.Profile
    {
        public AddressEntity()
        {
            //CreateMap<DTO.AddressDto, AddressEntity>()
            //.ForMember(dest => dest.Zip, opts => opts.MapFrom(src => src.ZipCode));
        }
        public string Street { get; set; } = "Unkown";
        public string City { get; set; } = "Unknow";
        public string State { get; set; } = "CO";
        public string Zip { get; set; } = "00000";
    }
}
