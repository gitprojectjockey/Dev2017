using System;
using DesignPatternEngine.StategyPattern.SalesTaxCalculator.Abstract;
using DesignPatternEngine.StategyPattern.SalesTaxCalculator.Entities;

namespace DesignPatternEngine.StategyPattern.SalesTaxCalculator.Concrete
{
    public class TaxOnOneHundredThousandOrBelow : ITaxFor<Product>
    {
        public double GetSalesTaxForProduct(Product product)
        {
            if (product.Price > 100000 || product.Price <= 10000)
                throw new ArgumentException("Method TaxOnOneHundredThousandOrBelow found a product price outside of a valid parameter range.");

            return (0.08 * product.Price);
        }
    }
}
