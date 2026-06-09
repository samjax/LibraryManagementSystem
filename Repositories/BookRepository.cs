using LibraryManagment.Api.Models;
using LibraryManagment.Api.Database;
using LibraryManagment.Api.DTOs;


namespace LibraryManagment.Api.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _libraryDbContext;
    public BookRepository(LibraryDbContext libraryDbContext)
    {
        _libraryDbContext = libraryDbContext;
    }
    public Book? CreateBook(Book book)
    {
       //check if the book already exists, if it exists return null
       // if it doesn't exist add it to the database and return the created book
      bool checkIfExists = _libraryDbContext.Books.Any(b => b.Title == book.Title); // if it exists throw an exception or return null
      if (checkIfExists)
      {
          return null;
      }
      _libraryDbContext.Books.Add(book);
      _libraryDbContext.SaveChanges();
      return book;
    }

    public bool DeleteBook(int bookId)
    {
        Book? book = _libraryDbContext.Books.FirstOrDefault(b => b.Id == bookId);
        if(book == null)
        {
            return false;
        }
        _libraryDbContext.Books.Remove(book);
        _libraryDbContext.SaveChanges();
        return true;
    }

    public IEnumerable<Book> GetAllBooks()
    {
        List<Book> books = _libraryDbContext.Books.ToList();
        return books;
    }

    public Book? GetBookById(int bookId)
    {
        Book? book = _libraryDbContext.Books.FirstOrDefault(b => b.Id == bookId);
        return book; 
    }

    public Book? UpdateBook(Book book, BookForCreationDto bookForCreationDto)
    {
        Book? book1 = _libraryDbContext.Books.FirstOrDefault(b => b.Description == book.Description);
        if(book1 == null)
        {
            return null;
        }
        book1.Title = bookForCreationDto.Title;
        book1.Description = bookForCreationDto.Description;
        book1.IsCheckedOut = book.IsCheckedOut;
        _libraryDbContext.SaveChanges(); 
        return book1;
    }
}
