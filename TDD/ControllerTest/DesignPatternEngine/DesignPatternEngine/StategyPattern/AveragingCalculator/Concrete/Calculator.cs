using System;
using System.Collections.Generic;
using DesignPatternEngine.StategyPattern.AveragingCalculator.Abstract;

namespace DesignPatternEngine.StategyPattern.AveragingCalculator.Concrete
{
    public class Calculator
    {
        public double CalculateAverageFor(List<double> values, IAveragingMethod averagingMethod)
        {
            // By passing in the class as a type interface we are dynamically choosing what class will be called.
            // If we pass in new AverageByMean() class the average will be calculated by auto choosing the
            // AverageByMean.AverageFor Method because it implements interface IAveragingMethod.

            if (values == null || values.Count == 0)
                throw new ArgumentException("Values parameter cannot be null or empty.");

            return averagingMethod.AverageFor(values);
        }
    }
}
