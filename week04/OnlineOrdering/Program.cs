using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        Address addr1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address addr2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        Customer cust1 = new Customer("Alice Johnson", addr1);
        Customer cust2 = new Customer("Bob Smith", addr2);

        Product prod1 = new Product("Laptop", "L123", 999.99, 1);
        Product prod2 = new Product("Smartphone", "S456", 499.99, 2);
        Product prod3 = new Product("Headphones", "H789", 199.99, 1);
        Product prod4 = new Product("Monitor", "M101", 299.99, 1);

        Orders order1 = new Orders(cust1);
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);

        Orders order2 = new Orders(cust2);
        order2.AddProduct(prod3);
        order2.AddProduct(prod4);

        Orders[] orders = new Orders[] { order1, order2 };
        int orderNumber = 1;
        foreach (Orders order in orders)
        {
            Console.WriteLine($"Order #{orderNumber}:");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice():F2}");
            Console.WriteLine("-----------------------------------");
            orderNumber++;
        }
    }
}