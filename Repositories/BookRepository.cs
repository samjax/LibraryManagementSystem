using LibraryManagment.Api.Models;
using LibraryManagment.Api.Database;


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
       // check if the book already exists, if it exists return null
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

    public Book? UpdateBook(Book book)
    {
        // Since we fetched the book by id in the service layer, the DbContext
        // has been tracking that object for changes. When we updated the 
        // title and description in service layer was aware of it so all we have
        // to do here is to save the changes.
        _libraryDbContext.SaveChanges(); 
        return book;
    }
}
