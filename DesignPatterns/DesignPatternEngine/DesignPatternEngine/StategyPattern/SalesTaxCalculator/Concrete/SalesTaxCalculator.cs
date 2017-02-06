using DesignPatternEngine.StategyPattern.SalesTaxCalculator.Abstract;
using DesignPatternEngine.StategyPattern.SalesTaxCalculator.Entities;
using System;

namespace DesignPatternEngine.StategyPattern.SalesTaxCalculator.Concrete
{
    public class SalesTaxCalculator
    {
        public double CalculateSalesTax (Product product, ITaxFor<Product> taxMethod )
        {
            if (product == null)
                throw new ArgumentException("Product parameter is null.");

            if(taxMethod == null)
                throw new ArgumentException("Tax method is null.");

            try
            {
                return Math.Round(taxMethod.GetSalesTaxForProduct(product),2);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
