using BookLibraryAPI.Data;
using BookLibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryAPI.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Book> GetAll() => _context.Books.Include(b => b.User).ToList();

    public Book? GetById(int id) => _context.Books.Include(b => b.User).FirstOrDefault(b => b.Id == id);

    public IEnumerable<Book> GetByUserId(int userId) =>
        _context.Books.Where(b => b.UserId == userId).Include(b => b.User).ToList();

    public void Add(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void Update(Book book)
    {
        _context.Books.Update(book);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var book = _context.Books.Find(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
