using AutoMapper;
using BasicAutoMapping.Entities;

namespace BasicAutoMapping.DTO
{
    public class FooDto : Profile
    {
        //Entity to DTO Map
        public FooDto()
        {
            CreateMap<FooEntity, FooDto>();
        }

        public string EmployeeFName { get; set; }
        public string EmployeeLName { get; set; }
    }
}
