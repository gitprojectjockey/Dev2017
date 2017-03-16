using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipsAndTricksData.Entities;

namespace TipsAndTricksData.DTO
{ 
    public class DtoMedicalPersonAndHospital : Profile
    {
        public DtoMedicalPersonAndHospital()
        {
            CreateMap<Doctor, DtoMedicalPersonAndHospital>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}
