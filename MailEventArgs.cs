internal class MailEventArgs : EventArgs
{
    private List<Product> products;
    public MailEventArgs(List<Product> products)
    {
        this.products = products;
    }
    public Conditions GetCondition()
    {
        return products[0].Condition;
    }
    public string GetDiscountInfo()
    {
        string result = string.Empty;
        foreach (Product product in products)
        {
            if (product.Condition == Conditions.SALE)
            {
                result += $"    * {product.Name} - {product.Price}$\n";
            }
        }
        return result;
    }
    public string GetNewProductsInfo()
    {
        string result = string.Empty;
        foreach (Product product in products)
        {
            if (product.Condition == Conditions.NEW)
            {
                result += $"    * {product.Name} - {product.Price}$\n";
            }
        }
        return result;
    }
}