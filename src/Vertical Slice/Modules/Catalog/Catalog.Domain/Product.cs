namespace VerticalSlice.Catalog.Domain;

public class Product
{
    public Guid Id { get; }
    public string Name { get; }
    public decimal Price { get; }

    public Product(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name requis");
        if (price <= 0) throw new ArgumentException("Price doit être > 0");

        Id = Guid.NewGuid();
        Name = name;
        Price = price;
    }
}
