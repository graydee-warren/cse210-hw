using System;

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    //Check if the customer lives in USA
    public bool LivesInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName() {return name;}
    public Address GetAddress() {return address;}
}