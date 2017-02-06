
using System;
using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Abstract;
using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Entities;


namespace DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Concrete
{
    public sealed class CompanyEntityValidator : CompanyEntityPropertyValidator, IEntityValidator
    {
        public bool IsEntityValid()
        {
            if (!IdExists())
            {
                return false;
            }

            if (!NameExists())
            {
                return false;
            }

            if (!StateExists())
            {
                return false;
            }

            if (!IdIsInt())
            {
                return false;
            }

            if (!NameIsString())
            {
                return false;
            }

            if (!StateIsString())
            {
                return false;
            }

            if (!StatesExists())
            {
                return false;
            }

            if (!StatesIsIEnumerableString())
            {
                return false;
            }
            return true;
        }
    }
}
