using LibraryManagment.Api.Services;
using Microsoft.AspNetCore.Mvc;
using LibraryManagment.Api.DTOs;

namespace LibraryManagment.Api.Controllers;

[ApiController]
[Route("api/Library")]
public class LibraryController : ControllerBase
{
    private readonly IBookService _bookService;

    public LibraryController(IBookService bookService)
    {
        _bookService = bookService;
    }

    // Add your API endpoints here
    [HttpGet("books")]
    public IActionResult GetBooks()
    {
        var books = _bookService.GetAllBooks();
        return Ok(books);
    }

    [HttpGet("books/{id}")]
    public IActionResult GetBook(int id)
    {
        var book = _bookService.GetBookById(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost("AddBook")]
    public IActionResult AddBook(BookForCreationDto bookForCreationDto)
    {
        var createdBook = _bookService.CreateBook(bookForCreationDto);
        if (createdBook == null)
        {
            return BadRequest("Book already exists.");
        }
        return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
    }

    [HttpDelete("books/{id}")]
    public IActionResult DeleteBook(int id)
    {
        if (_bookService.DeleteBook(id))
        {
            return Ok();
        }
        return NotFound();
    }

    [HttpPut("books/{id}")]
    public IActionResult UpdateBook(int id, BookForUpdateDto bookForUpdateDto)
    {
        var updatedBook = _bookService.UpdateBook(id, bookForUpdateDto);
        if (updatedBook == null)
        {
            return NotFound();
        }
        return Ok(updatedBook);
    }
}