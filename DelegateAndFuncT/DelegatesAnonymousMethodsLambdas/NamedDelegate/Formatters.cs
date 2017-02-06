using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAnonymousMethodsLambdas.NamedDelegate
{
    public static class Formatters
    {
        public static string Default(Person input)
        {
            return input.ToString();
        }

        public static string FirstNameToUpper(Person input)
        {
            return input.FirstName.ToUpper();
        }

        public static string LastNameToUpper(Person input)
        {
            return input.LastName.ToUpper();
        }

        public static string FullNameToLower(Person input)
        {
            return $"{input.LastName.ToLower()}, {input.FirstName}";
        }
    }
}
