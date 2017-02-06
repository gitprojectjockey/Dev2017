using DesignPatternEngine.IteratorPattern.Entities;
using DesignPatternEngine.IteratorPattern.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternEngine.IteratorPattern.Concrete
{
    public class IterateProducts
    {
        public static IEnumerable<Product> GetIteratorPatternListOfProducts(List<Product> products)
        {
            Aggregate aggregate = new Aggregate();
            for (int i = 0; i < products.Count; i++)
                aggregate[i] = products[i];

            IIterator iterator = aggregate.GetIterator();
            for (var item = iterator.FirstItem;
                            iterator.IsDone == false;
                     item = iterator.NextItem)
            {
                yield return item;
            }
        }
    }
}
