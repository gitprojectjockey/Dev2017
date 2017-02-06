using System.Collections.Generic;
namespace DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Entities
{
    public class Company
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public IEnumerable<string> States { get; set; }
    }
}
