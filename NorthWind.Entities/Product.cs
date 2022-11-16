
namespace NorthWind.Entities;

public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal? UnitPrice { get; set; }
    public int? UnitsInStock { get; set; }
    public Category Category { get; set; }
}
