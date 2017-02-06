using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Abstract;
using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Entities;
using System;
using System.Linq;
using System.Reflection;

namespace DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Concrete
{
    public class ProductEntityPropertyValidator : IPropertyValidator
    {
        PropertyInfo[] _propertyInfos;
        Type _type;
        public ProductEntityPropertyValidator()
        {
            _type = typeof(Product);
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

        protected bool PriceExists()
        {
            if (_propertyInfos.FirstOrDefault(p => p.Name.ToLower() == "price") != null)
            {
                return true;
            }
            return false;
        }

        protected bool PriceIsDouble()
        {
            if (_propertyInfos.FirstOrDefault(p => p.Name.ToLower() == "price").PropertyType == typeof(double))
            {
                return true;
            }
            return false;
        }
    }
}
