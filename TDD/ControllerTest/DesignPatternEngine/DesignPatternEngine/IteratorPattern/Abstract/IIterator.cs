
using DesignPatternEngine.IteratorPattern.Entities;

namespace DesignPatternEngine.IteratorPattern.Abstract
{
    public interface IIterator
    {
        Product FirstItem { get; }
        Product NextItem { get; }
        Product CurrentItem { get; }
        bool IsDone { get; }
    }
}
