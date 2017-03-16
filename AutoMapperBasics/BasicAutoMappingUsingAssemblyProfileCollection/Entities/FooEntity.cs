using AutoMapper;
using BasicAutoMapping.DTO;

namespace BasicAutoMapping.Entities
{
    public class FooEntity : Profile
    {
        //DTO to Entity Map
        public FooEntity()
        {
            CreateMap<FooDto,FooEntity>();
        }
        public string EmployeeFName { get; set; }
        public string EmployeeLName { get; set; }
    }
}
