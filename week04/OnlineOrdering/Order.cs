using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.Marshalling;

class Order 
{
    private List<Product> products;
    private Customer customer;

    public Order (Customer customer)
    {
        this.customer = customer;
        this.products = new List<Product>();
    }

    //Add product to the order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    //Calculate the total cost of the order
    public decimal CalculateTotalCost()
    {
        decimal productTotal = 0m;
        foreach(Product product in products)
        {
            productTotal += product.GetTotalCost();
        }
        decimal shippingCost = customer.LivesInUSA() ? 5m : 35m;
        return productTotal + shippingCost;
    }

    //Packing Label
    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach(Product product in products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n"; 
        }
        return label;
    }

    //Shipping Label
    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}