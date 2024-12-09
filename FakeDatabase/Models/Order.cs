namespace FakeDatabase.Models;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }

    // En order kan ha flera produkter (inte nullable!)
    // One to many!
    public List<Product> Items { get; set; } = new List<Product>();

    // En order kan ha EN faktura (inte nullable!)
    // One to One!
    public Invoice Invoice { get; set; }
    public decimal CalculateTotal()
    {
        return Items.Sum(item => item.Price * item.Quantity);
    }
}
