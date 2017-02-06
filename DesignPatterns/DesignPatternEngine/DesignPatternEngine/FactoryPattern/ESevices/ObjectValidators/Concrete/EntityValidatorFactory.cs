using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Abstract;
using DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Entities;
using System;


namespace DesignPatternEngine.FactoryPattern.ESevices.ObjectValidators.Concrete
{
    public static class EntityValidatorFactory<TEntity> where TEntity : class
    {
        public static IEntityValidator CreateEntityValidator()
        {

            switch (typeof(TEntity).Name.ToLower())
            {
                case "product":
                    return new ProductEntityValidator() as IEntityValidator;
                case "employee":
                    return new EmployeeEntityValidator() as IEntityValidator;
                case "company":
                    return new CompanyEntityValidator() as IEntityValidator;
                default:
                    throw new ArgumentException("EntityValidatorFactory does not support the creation of this TEntity type. ");
            }
        }
        
    }
}
