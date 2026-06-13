using LibraryManagment.Api.DTOs;
using LibraryManagment.Api.Repositories;
using LibraryManagment.Api.Models;

namespace LibraryManagment.Api.Services;

public class BookService : IBookService 
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public BookDto? CreateBook(BookForCreationDto bookForCreationDto)
    {
        var book = _bookRepository.CreateBook(new Book
        {
            Title = bookForCreationDto.Title,
            Description = bookForCreationDto.Description,
            IsCheckedOut = false
        });
        if (book == null)
        {
            return null;
        }
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            IsCheckedOut = book.IsCheckedOut
        };
    }

    public bool DeleteBook(int bookId)
    {
        if (_bookRepository.DeleteBook(bookId))
        {
            return true;
        }
        return false;
    }

    public IEnumerable<BookDto> GetAllBooks()
    {
        List<BookDto> bookDtos = new List<BookDto>();
        var books = _bookRepository.GetAllBooks();
        foreach (var book in books)        
        {
            BookDto bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                IsCheckedOut = book.IsCheckedOut
            };
            bookDtos.Add(bookDto);      
        }
        return bookDtos;
    }

    public BookDto? GetBookById(int bookId)
    {
        Book? book = _bookRepository.GetBookById(bookId);
        if (book == null)        {
            return null;
        }
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            IsCheckedOut = book.IsCheckedOut
        };  
    }

    public BookDto? UpdateBook(int bookId, BookForUpdateDto bookForUpdateDto)
    {
        Book? existingBook = _bookRepository.GetBookById(bookId);
        if (existingBook == null)
        {
            return null;
        }
        existingBook.Title = bookForUpdateDto.Title;
        existingBook.Description = bookForUpdateDto.Description;
        
        Book? updatedBook = _bookRepository.UpdateBook(existingBook);
        if (updatedBook == null)
        {
            return null;
        }
        return new BookDto
        {
            Id = updatedBook.Id,
            Title = updatedBook.Title,
            Description = updatedBook.Description,
            IsCheckedOut = updatedBook.IsCheckedOut
        };
    }
}
