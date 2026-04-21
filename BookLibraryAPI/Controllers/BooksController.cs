using Microsoft.AspNetCore.Mvc;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories;

namespace BookLibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookRepository _repo;

    public BooksController(IBookRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_repo.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _repo.GetById(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpGet("user/{userId}")]
    public IActionResult GetByUser(int userId) => Ok(_repo.GetByUserId(userId));

    [HttpPost]
    public IActionResult Create(Book book)
    {
        
        if (book.Rating < 1 || book.Rating > 5)
            return BadRequest("El rating debe estar entre 1 y 5");

        _repo.Add(book);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Book book)
    {
        if (id != book.Id) return BadRequest();
        if (book.Rating < 1 || book.Rating > 5)
            return BadRequest("El rating debe estar entre 1 y 5");

        _repo.Update(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return NoContent();
    }
}
