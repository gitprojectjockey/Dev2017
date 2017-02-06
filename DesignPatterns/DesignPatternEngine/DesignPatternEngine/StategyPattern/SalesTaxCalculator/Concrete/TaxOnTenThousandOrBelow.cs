using DesignPatternEngine.StategyPattern.SalesTaxCalculator.Abstract;
using DesignPatternEngine.StategyPattern.SalesTaxCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternEngine.StategyPattern.SalesTaxCalculator.Concrete
{
    public class TaxOnTenThousandOrBelow : ITaxFor<Product>
    {
        public double GetSalesTaxForProduct(Product product)
        {
            if (product.Price > 10000 || product.Price == 0)
                throw new ArgumentException("Method TaxOnTenThousandOrBelow found a product price outside of a valid parameter range.");

            return (0.05 * product.Price);
        }
    }
}
