using System;
using System.Collections.Generic;

namespace DesignPatternEngine.StategyPattern.AveragingCalculator.Abstract
{
    public interface IAveragingMethod
    {
        double AverageFor(List<Double> values);
    }
}
