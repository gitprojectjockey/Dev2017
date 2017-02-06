
using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Abstract;


namespace DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Concrete
{
    public sealed class EmployeeEntityValidator : EmployeeEntityPropertyValidator, IEntityValidator
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

            if (!SalaryExists())
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
            if (!SalaryIsDouble())
            {
                return false;
            }

            return true;
        }
    }
}




