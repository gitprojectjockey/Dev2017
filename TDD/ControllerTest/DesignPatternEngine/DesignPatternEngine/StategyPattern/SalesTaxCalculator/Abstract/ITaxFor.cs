namespace DesignPatternEngine.StategyPattern.SalesTaxCalculator.Abstract
{
    public interface ITaxFor<TEntity> where TEntity : class
    {
        double GetSalesTaxForProduct(TEntity product);
    }
}
