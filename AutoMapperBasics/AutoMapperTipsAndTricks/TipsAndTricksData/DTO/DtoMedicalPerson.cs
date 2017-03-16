using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipsAndTricksData.Entities;

namespace TipsAndTricksData.DTO
{
    public class DtoMedicalPerson : Profile
    {
        public DtoMedicalPerson()
        {
            CreateMap<Doctor, DtoMedicalPerson>()
                .ForMember(dest => dest.Title, opt => opt.Ignore());
        }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HospitalName { get; set; }
    }
}

