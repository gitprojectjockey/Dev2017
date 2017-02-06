using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Abstract;


namespace DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Concrete
{
    public sealed class ProductEntityValidator : ProductEntityPropertyValidator, IEntityValidator
    {
        public bool IsEntityValid()
        {
            if(!IdExists())
            {
                return false;
            }

            if(!NameExists())
            {
                return false;
            }

            if (!PriceExists())
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
            if (!PriceIsDouble())
            {
                return false;
            }

            return true;
        }
    }
}
