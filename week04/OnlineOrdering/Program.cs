using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //Create Addresses
        Address address1 = new Address("123 Maple St", "Provo", "UT", "USA");
        Address address2 = new Address("456 Side St", "Toronta", "ON", "Canada");

        //Create Customers
        Customer customer1 = new Customer("Johny Doe", address1);
        Customer customer2 = new Customer("Jane Doe", address2);

        // Create products
        Product product1 = new Product("Laptop", "LAP123", 999.99m, 1);
        Product product2 = new Product("Mouse", "MOU456", 29.99m, 2);
        Product product3 = new Product("Keyboard", "KEY789", 59.99m, 1);
        Product product4 = new Product("Monitor", "MON101", 199.99m, 2);

        //Create order 1 (USA)
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        //Order 2 (Non-USA)
        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        //Display Results Order 1
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine("---------------------\n");

        //Display Results Order 2 
        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}");
    }
}