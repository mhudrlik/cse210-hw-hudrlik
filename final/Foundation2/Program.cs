using System;

public class Program
{
    public static void Main(string[] args)
    {
        Address address1 = new Address("1581 Parkwood Circle", "Idaho Falls", "ID", "USA");
        Customer customer1 = new Customer("Matt Hudrlik", address1);
        List<Product> products1 = new List<Product>
        {
            new Product("Monitor", 1, 600, 2),
            new Product("Mouse", 2, 20, 2),
            new Product("Keyboard", 3, 20, 2)
        };
        Order order1 = new Order(products1, customer1);

        Address address2 = new Address("1234 John Adams Road", "Anytown", "Ottowa", "Canada");
        Customer customer2 = new Customer("Rick James", address2);
        List<Product> products2 = new List<Product>
        {
            new Product("Iphone SE", 4, 800, 1),
            new Product("Airpods", 5, 180, 1),
            new Product("Magsafe Charger", 6, 40, 2)
        };
        Order order2 = new Order(products2, customer2);

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice()}");

        Console.WriteLine();

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice()}");
    }
}