using BookLibraryAPI.Models;

namespace BookLibraryAPI.Repositories;

public interface IBookRepository
{
    IEnumerable<Book> GetAll();
    Book? GetById(int id);
    IEnumerable<Book> GetByUserId(int userId);
    void Add(Book book);
    void Update(Book book);
    void Delete(int id);
}
