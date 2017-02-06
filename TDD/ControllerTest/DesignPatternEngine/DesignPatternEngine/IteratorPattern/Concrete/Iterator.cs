using DesignPatternEngine.IteratorPattern.Entities;
using DesignPatternEngine.IteratorPattern.Abstract;


namespace DesignPatternEngine.IteratorPattern.Concrete
{
    public class Iterator : IIterator
    {
        private IAggregate _aggregate { get; set; }
        private int _currentIndex { get; set; }

        public Iterator(IAggregate iteration)
        {
            _aggregate = iteration;
            _currentIndex = 0;
        }
        public Product FirstItem
        {
            get
            {
                _currentIndex = 0;
                return _aggregate[_currentIndex];
            }
        }
        public Product NextItem
        {
            get
            {
                _currentIndex += 1;
                return IsDone == false ? _aggregate[_currentIndex] : null;
            }
        }
        public Product CurrentItem
        {
            get
            {
                return _aggregate[_currentIndex];
            }
        }
        public bool IsDone
        {
            get { return _currentIndex >= _aggregate.Count; }
        }
    }
}
