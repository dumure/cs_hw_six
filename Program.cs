Customer customer = new Customer() { FirstName = "Rasul",
                                     LastName = "Umud",
                                     Email = "sdjadjsadjasid@gmail.com",
                                     PhoneNumber = "+994 423-423-43-23" };

Store store = new Store() { Name = "Bravo" };
store.MailHandler = customer.RecieveMail;
store.SMSHandler = customer.RecieveSMS;
store.AddNewProducts(new List<Product> { new Product("Apple", 100.0), new Product("Pear", 200.0) });
store.Discount(0, 25, 1, 50);
store.SendSMS("sdasdfds");
