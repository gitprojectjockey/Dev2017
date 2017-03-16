using TipsAndTricksData.Entities;

namespace TipsAndTricksData.DTO
{
    public class DtoHealthCareWorker : AutoMapper.Profile
    {
        public DtoHealthCareWorker()
        {
            CreateMap<Doctor, DtoHealthCareWorker>()
                .ForMember(dest => dest.Information, opts => opts.MapFrom(src => $@"FullName: {src.FirstName} {src.LastName} Title: {src.Title} Hostpital: {src.Hospital.Name}"));
        }

        public string Information { get; set; }

    }
}
