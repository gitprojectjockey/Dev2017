using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Abstract
{
    public interface IPropertyValidator
    {
        bool IdExists();

        bool IdIsInt();

        bool NameExists();

        bool NameIsString();
    }
}
