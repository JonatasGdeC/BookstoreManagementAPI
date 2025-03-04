namespace BookstoreManagementAPI.Models;

public class Book
{
  public Guid Id { get; init; } = Guid.NewGuid();
  public required string Title { get; set; }
  public required string Author { get; set; }
  public required string Genre { get; set; }
  public double Price { get; set; }
  public int Quantity { get; set; }
}
