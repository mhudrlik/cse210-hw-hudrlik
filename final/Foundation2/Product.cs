public class Product
{
    private string name;
    private int productId;
    private decimal price;
    private int quantity;

    public string Name { get => name; set => name = value; }
    public int ProductId { get => productId; set => productId = value; }
    public decimal Price { get => price; set => price = value; }
    public int Quantity { get => quantity; set => quantity = value; }

    public Product(string name, int productId, decimal price, int quantity)
    {
        this.Name = name;
        this.ProductId = productId;
        this.Price = price;
        this.Quantity = quantity;
    }

    public decimal GetTotalCost()
    {
        return Price * Quantity;
    }
}