public class Customer
{
    private string name;
    private Address address;

    public string Name { get => name; set => name = value; }
    public Address Address { get => address; set => address = value; }

    public Customer(string name, Address address)
    {
        this.Name = name;
        this.Address = address;
    }

    public bool IsInUSA()
    {
        return Address.IsInUSA();
    }
}