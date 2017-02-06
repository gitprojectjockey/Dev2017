using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Library
{
    public class FizzBuzzer : IFizzBuzzer
    {
        public string GetValue(int input = 1)
        {
            string output = string.Empty;

            if (input % 3 == 0)
                output += "Fizz";

            if (input % 5 == 0)
                output += "Buzz";

            else if (string.IsNullOrEmpty(output))
                output = input.ToString();

            return output;
        }
    }
}
