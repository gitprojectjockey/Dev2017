using System.Collections.Generic;
using TipsAndTricksData.Entities;

namespace TipsAndTricksData.Entities
{
    public class Hospital 
    {
        public Hospital()
        {
            Doctors = new List<Doctor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
