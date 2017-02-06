using System;
using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Abstract;
using System.Reflection;
using System.Linq;
using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Entities;

namespace DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Concrete
{
    public class EmployeeEntityPropertyValidator : IPropertyValidator
    {
        PropertyInfo[] _propertyInfos;
        Type _type;
        public EmployeeEntityPropertyValidator()
        {
            _type = typeof(Employee);
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

        public bool SalaryExists()
        {
            if (_propertyInfos.FirstOrDefault(p => p.Name.ToLower() == "salary") != null)
            {
                return true;
            }
            return false;
        }
        public bool SalaryIsDouble()
        {
            if (_propertyInfos.FirstOrDefault(p => p.Name.ToLower() == "salary").PropertyType == typeof(double))
            {
                return true;
            }
            return false;
        }
    }
}
