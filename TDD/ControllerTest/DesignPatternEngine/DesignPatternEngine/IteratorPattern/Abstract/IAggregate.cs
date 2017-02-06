using DesignPatternEngine.IteratorPattern.Entities;
using System.Collections.Generic;

namespace DesignPatternEngine.IteratorPattern.Abstract
{
    public interface IAggregate 
    {
        IIterator GetIterator();
        Product this[int itemIndex] { set; get; }
        int Count { get; }
    }
}
