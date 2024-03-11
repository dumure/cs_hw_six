using System;

internal class Store
{
    public EventHandler<MailEventArgs> MailHandler;
    public EventHandler<SMSEventArgs> SMSHandler;
    public string Name { get; set; }
    private List<Product> products;
    public Store()
    {
        products = new List<Product>();
    }
    public void SendSMS(string msg)
    {
        SMSHandler(this, new SMSEventArgs() { SMS = msg });
    }
    public void SendMail(List<Product> products)
    {
        MailHandler(this, new MailEventArgs(products));
    }
    public void AddNewProducts(List<Product> products)
    {
        foreach (var product in this.products)
        {
            if (product.Condition != Conditions.SALE)
            {
                product.Condition = Conditions.OLD;
            }
        }
        foreach (var product in products)
        {
            this.products.Add(product);
        }
        SendMail(products);
        SendSMS("Hello! Please check our recently mail about new products.");
    }
    public void RemoveProduct(Product product)
    {
        products.Remove(product);
    }
    public void Clear()
    {
        products.Clear();
    }
    public void Discount(params int[] indexes)
    // в этом методе нечетные параметры отвечают за индексы тех продуктов, которым мы хотим снизить цену
    // а четные параметры отвечают за процент насколько мы хотим снизить цену
    {
        if (indexes.Length % 2 == 0 && indexes.Length / 2 <= products.Count)
        {
            for (int i = 0; i < indexes.Length; i += 2)
            {
                if (i / 2 >= 0 && i / 2 < products.Count)
                {
                    products[i / 2].Condition = Conditions.SALE;
                    if (indexes[i + 1] < 100 && indexes[i + 1] > 0)
                    {
                        products[i / 2].Price *= (1 - indexes[i + 1] / 100.0);
                    }
                }
            }
            SendMail(products);
            SendSMS("Hello! Please check our recently mail about discounted produtcs.");
        }
    }
}

