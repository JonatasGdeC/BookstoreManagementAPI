namespace BookstoreManagementAPI.Communication.Requests;

public class RequestUpdateBookJson
{
  public required string Title { get; set; }
  public required string Author { get; set; }
  public required string Genre { get; set; }
  public double Price { get; set; }
  public int Quantity { get; set; }
}
