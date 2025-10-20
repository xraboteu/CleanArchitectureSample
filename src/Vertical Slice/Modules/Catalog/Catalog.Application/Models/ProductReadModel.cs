namespace VerticalSlice.Catalog.Application.Models;

public class ProductReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
}
