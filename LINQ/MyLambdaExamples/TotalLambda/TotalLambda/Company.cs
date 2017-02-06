using System.Collections.Generic;
using System.Linq;
namespace TotalLambda
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public IEnumerable<string> AllStates { get; set; }

        public static IEnumerable<Company> GetAllCompanies()
        {
            List<Company> listCompanies = new List<Company>()
        {
            new Company {ID = 301,Name = "TKE Inc",State= "CO", AllStates = new List<string>() {"CO","MI","NY"} },
            new Company {ID = 302,Name = "Microsoft",State= "TX", AllStates = new List<string>() {"CO","MI","NY","MA","WA","TX"} },
            new Company {ID = 303,Name = "Trulie",State= "NY",AllStates = new List<string>() {"MO","MI","OH","MA","WA","TX","AL","FLA"}   }
        };
            return listCompanies;
        }
    }
}
