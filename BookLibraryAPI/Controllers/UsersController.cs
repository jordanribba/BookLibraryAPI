using Microsoft.AspNetCore.Mvc;
using BookLibraryAPI.Models;
using BookLibraryAPI.Repositories;

namespace BookLibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _repo;

    public UsersController(IUserRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_repo.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _repo.GetById(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        _repo.Add(user);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, User user)
    {
        if (id != user.Id) return BadRequest();
        _repo.Update(user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repo.Delete(id);
        return NoContent();
    }
}
