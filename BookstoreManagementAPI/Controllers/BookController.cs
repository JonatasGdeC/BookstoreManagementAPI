using BookstoreManagementAPI.Communication.Requests;
using BookstoreManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
  private static List<Book> _books = new List<Book>();

  [HttpPost]
  [ProducesResponseType(typeof(RequestRegisteBookJson), StatusCodes.Status201Created)]
  public IActionResult CreateBook([FromBody] RequestRegisteBookJson request)
  {
    var response = new RequestRegisteBookJson
    {
      Title = request.Title,
      Author = request.Author,
      Genre = request.Genre,
      Price = request.Price,
      Quantity = request.Quantity
    };

    //Simulation DB
    var newBook = new Book
    {
      Id = Guid.NewGuid(),
      Title = request.Title,
      Author = request.Author,
      Genre = request.Genre,
      Price = request.Price,
      Quantity = request.Quantity
    };
    _books.Add(newBook);

    return Created(string.Empty, response);
  }

  [HttpGet]
  [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
  public IActionResult GetAllBooks()
  {
    return Ok(_books);
  }

  [HttpPut("{id}")]
  [ProducesResponseType(typeof(RequestUpdateBookJson), StatusCodes.Status204NoContent)]
  public IActionResult UpdateBook(Guid id, [FromBody] RequestUpdateBookJson request)
  {
    //Simulation DB
    var book = _books.FirstOrDefault(b => b.Id == id);
    if (book == null)
    {
      return NotFound();
    }

    book.Title = request.Title;
    book.Author = request.Author;
    book.Genre = request.Genre;
    book.Price = request.Price;
    book.Quantity = request.Quantity;

    return NoContent();
  }

  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  public IActionResult DeleteBook(Guid id)
  {
    //Simulation DB
    _books.RemoveAll(b => b.Id == id);

    return NoContent();
  }
}
