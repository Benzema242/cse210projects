using System.Collections.Generic;
using System.Text;

public class Orders
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Orders(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (Product product in products)
        {
        total += product.GetTotalPrice();
    }
    double shipping = customer.LivesInUSA() ? 5 : 35;
    return total + shipping;
}

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        foreach (Product product in products)
        {
            sb.AppendLine($"Product: {product.GetName()}, ID: {product.GetProductId()}, Quantity: {product.GetQuantity()}");
        }
        return sb.ToString();
    }
    public string GetShippingLabel()
    {
        return $"{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}
