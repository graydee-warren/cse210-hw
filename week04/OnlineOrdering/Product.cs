using System;
using System.Security.Cryptography.X509Certificates;

class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product (string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    //Calculate the total cost of this product
    public decimal GetTotalCost()
    {
        return price + quantity;
    }

    //Getters
    public string GetName() {return name;}
    public string GetProductId() {return productId;}
    public decimal GetPrice() {return price;}
    public int GetQuantity() {return quantity;}
    
}