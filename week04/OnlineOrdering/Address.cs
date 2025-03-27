using System;

class Address
{
    private string street;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string street, string city, string stateProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    //Check if address is in the USA
    public bool IsInUSA()
    {
        return country.ToLower() == "usa" || country.ToLower() == "united states";
    }

    //full address as string
    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateProvince}\n{country}";
    }

    //Getters
    public string GetStreet() {return street;}
    public string GetCity() {return city;}
    public string GetStateProvince() {return stateProvince;}
    public string GetCountry() {return country;}
}