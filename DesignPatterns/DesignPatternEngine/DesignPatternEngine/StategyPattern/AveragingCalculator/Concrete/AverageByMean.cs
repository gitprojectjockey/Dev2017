using System.Collections.Generic;
using System.Linq;
using DesignPatternEngine.StategyPattern.AveragingCalculator.Abstract;
namespace DesignPatternEngine.StategyPattern.AveragingCalculator.Concrete
{
    public class AverageByMean : IAveragingMethod
    {
        public double AverageFor(List<double> values)
        {
            return (values.Sum()/values.Count);
        }
    }
}
