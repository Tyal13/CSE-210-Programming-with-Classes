using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Alex Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-100", 19.99, 2));
        order1.AddProduct(new Product("USB-C Cable", "UC-220", 8.50, 3));
        order1.AddProduct(new Product("Laptop Stand", "LS-310", 34.00, 1));

        Address address2 = new Address("45 King Street", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Maria Lopez", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Desk Lamp", "DL-450", 24.75, 1));
        order2.AddProduct(new Product("Notebook Pack", "NP-600", 6.25, 4));

        DisplayOrder(order1);
        Console.WriteLine();
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order.GetTotalPrice():F2}");
    }
}
