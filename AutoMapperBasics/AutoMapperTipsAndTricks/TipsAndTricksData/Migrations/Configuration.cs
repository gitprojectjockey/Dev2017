namespace TipsAndTricksData.Migrations
{
    using Entities;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;

    internal sealed class Configuration : DbMigrationsConfiguration<TipsAndTricksData.Context.TipsAndTricksDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TipsAndTricksData.Context.TipsAndTricksDBContext context)
        {
            try
            {
                var hospitals = new List<Hospital>()
             {
                 new Hospital { Name = "Los Angeles Central",Street="66667 Taco Time Blvd",City="LA", State = "CA",ZipCode="98789" },
                 new Hospital { Name = "NY City Hospital",Street="678 North West Willis",City="NY",  State = "NY" ,ZipCode="09456" },
                 new Hospital { Name = "Ridge View",Street="44 Pine St",City="Denver",  State = "CO" ,ZipCode="10201" },
                 new Hospital { Name = "St Joseph Memorial",Street="33 Memorial Way",City = "Cleveland",  State = "OH",ZipCode="45436"  }
             };

                foreach (var hospital in hospitals)
                    context.Hospitals.AddOrUpdate(h => h.Name, hospital);

                context.SaveChanges();

                var doctors = new List<Doctor>()
             {
                 new Doctor {Title="DR", FirstName = "William",LastName="Landyerd",HospitalId = 1 },
                 new Doctor {Title="DR", FirstName = "Debbie",LastName="Tellco" ,HospitalId = 2 },
                 new Doctor {Title="DR", FirstName = "Bill",LastName="Smith" ,HospitalId = 3 },
                 new Doctor {Title="Intern", FirstName = "Joe",LastName="Beste",HospitalId = 4 },
                 new Doctor {Title="Nurse", FirstName = "Eric",LastName="Williamson",HospitalId = 1 },
                 new Doctor {Title="DR", FirstName = "Betty",LastName="Joseph" ,HospitalId = 2 },
                 new Doctor {Title="Intern", FirstName = "Sam",LastName="White" ,HospitalId = 3 },
                 new Doctor {Title="Intern", FirstName = "Joe",LastName="Rigger",HospitalId = 4 }
             };

                foreach (var doctor in doctors)
                    context.Doctors.AddOrUpdate(d => d.LastName, doctor);

                context.SaveChanges();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
