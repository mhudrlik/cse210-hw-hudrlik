public class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public string StreetAddress { get => streetAddress; set => streetAddress = value; }
    public string City { get => city; set => city = value; }
    public string State { get => state; set => state = value; }
    public string Country { get => country; set => country = value; }

    public Address(string streetAddress, string city, string state, string country)
    {
        this.StreetAddress = streetAddress;
        this.City = city;
        this.State = state;
        this.Country = country;
    }

    public bool IsInUSA()
    {
        return Country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString()
    {
        return $"{StreetAddress}\n{City}, {State}, {Country}";
    }
}