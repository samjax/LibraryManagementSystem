using LibraryManagment.Api.Models;
using LibraryManagment.Api.DTOs;
namespace LibraryManagment.Api.Repositories;

public interface IBookRepository
{
    Book? CreateBook(Book book);
    Book? GetBookById(int bookId);
    IEnumerable<Book> GetAllBooks();
    Book? UpdateBook(Book book, BookForCreationDto bookForCreationDto);
    bool DeleteBook(int bookId);
}
