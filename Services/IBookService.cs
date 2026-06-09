using LibraryManagment.Api.DTOs;

namespace LibraryManagment.Api.Services;

public interface IBookService
{
    BookDto? CreateBook(BookForCreationDto bookForCreationDto);
    BookDto? GetBookById(int bookId);
    IEnumerable<BookDto> GetAllBooks();
    BookDto? UpdateBook(int bookId, BookForCreationDto bookForCreationDto);
    bool DeleteBook(int bookId);
}
