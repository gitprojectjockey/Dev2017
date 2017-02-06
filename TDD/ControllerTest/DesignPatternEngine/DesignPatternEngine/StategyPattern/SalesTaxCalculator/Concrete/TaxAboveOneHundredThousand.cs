using DesignPatternEngine.StategyPattern.SalesTaxCalculator.Abstract;
using DesignPatternEngine.StategyPattern.SalesTaxCalculator.Entities;
using System;

namespace DesignPatternEngine.StategyPattern.SalesTaxCalculator.Concrete
{
   public class TaxAboveOneHundredThousand : ITaxFor<Product>
    {
        public double GetSalesTaxForProduct(Product product)
        {
            if (product.Price <= 100000)
                throw new ArgumentException("Method TaxOnOneHundredThousandOrAbove found a product price outside of a valid parameter range.");

            return (0.085*product.Price);
        }
    }
}
