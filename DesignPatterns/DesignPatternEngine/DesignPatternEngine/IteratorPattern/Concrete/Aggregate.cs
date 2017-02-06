using DesignPatternEngine.IteratorPattern.Abstract;
using System.Collections.Generic;
using DesignPatternEngine.IteratorPattern.Entities;
using System;

namespace DesignPatternEngine.IteratorPattern.Concrete
{
    public class Aggregate : IAggregate
    {
        private List<Product> _values { get; set; }

        public Aggregate()
        {
            _values = new List<Product>();
        }

        public int Count
        {
            get { return _values.Count; }
        }

        public Product this[int itemIndex]
        {
            get { return itemIndex < _values.Count ? _values[itemIndex] : null; }
            set { _values.Add(value); }
        }

        public IIterator GetIterator()
        {
            return new Iterator(this);
        }
    }
}
