using System.Collections.Generic;
namespace DesignPatternEngine.IteratorPattern.Entities
{
    public class Company
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public IEnumerable<string> States { get; set; }
    }
}
