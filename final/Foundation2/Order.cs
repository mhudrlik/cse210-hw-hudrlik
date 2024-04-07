using System;

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = products.Sum(p => p.GetTotalCost());
        if (customer.IsInUSA())
            totalPrice += 5;
        else
            totalPrice += 35;
        return totalPrice;
    }

    public string GetPackingLabel()
    {
        return string.Join("\n", products.Select(p => $"Name: {p.Name}, Product ID: {p.ProductId}, Quantity: {p.Quantity}"));
    }

    public string GetShippingLabel()
    {
        return $"Customer Name: {customer.Name}\n{customer.Address}";
    }
}