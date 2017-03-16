using AutoMapper;
using BasicAutoMapping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAutoMapping.DTO
{
    public class AddressDto : Profile
    {
        public AddressDto()
        {
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
