using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Abstract;
using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Concrete
{
    public class CompanyEntityPropertyValidator : IPropertyValidator
    {
        PropertyInfo[] _propertyInfos;
        Type _type;
        public CompanyEntityPropertyValidator()
        {
            _type = typeof(Company);
            _propertyInfos = _type.GetProperties();
        }

        public bool IdExists()
        {
            if (_propertyInfos.FirstOrDefault(p => p.Name.ToLower() == "id") != null)
            {
                return true;
            }
            return false;
        }

        public bool IdIsInt()
        {
            if (_propertyInfos.FirstOrDefault(p => p.Name.ToLower() == "id").PropertyType == typeof(int))
            {
                return true;
            }
            return false;
        }

        public bool NameExists()
        {
            if (_propertyInfos.FirstOrDefault(p => p.Name.ToLower() == "name") != null)
            {
                return true;
            }
            return false;
        }

        public bool NameIsString()
        {
            if (_propertyInfos.FirstOrDefault(p => p.Name.ToLower() == "name").PropertyType == typeof(string))
            {
                return true;
            }
            return false;
        }

        public bool StateExists()
        {
            if (_propertyInfos.FirstOrDefault(p => p.Name.ToLower() == "state") != null)
            {
                return true;
            }
            return false;
        }
        public bool StateIsString()
        {
            if (_propertyInfos.FirstOrDefault(p => p.Name.ToLower() == "state").PropertyType == typeof(string))
            {
                return true;
            }
            return false;
        }
        public bool StatesExists()
        {
            if (_propertyInfos.FirstOrDefault(p => p.Name.ToLower() == "states") != null)
            {
                return true;
            }
            return false;
        }
        public bool StatesIsIEnumerableString()
        {
            if (_propertyInfos.FirstOrDefault(p => p.Name.ToLower() == "states").PropertyType == typeof(IEnumerable<string>))
            {
                return true;
            }
            return false;
        }
    }
}
