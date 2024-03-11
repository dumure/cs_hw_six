using System.Runtime;

internal class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public void RecieveSMS(object sender, SMSEventArgs args)
    {
        Console.WriteLine($"{FirstName} {LastName} received an SMS from {(sender as Store)?.Name} store:");
        Console.Write("   ");
        Console.WriteLine(args?.SMS);
    }
    public void RecieveMail(object sender, MailEventArgs args)
    {
        Console.WriteLine($"{FirstName} {LastName} received a mail from {(sender as Store)?.Name} store:");
        if (args.GetCondition() == Conditions.SALE)
        {
            Console.WriteLine("   Discounted products' list:");
            Console.Write(args?.GetDiscountInfo());
        }
        else if (args.GetCondition() == Conditions.NEW)
        {
            Console.WriteLine("   New products' list:");
            Console.Write(args?.GetNewProductsInfo());
        }
    }
}
