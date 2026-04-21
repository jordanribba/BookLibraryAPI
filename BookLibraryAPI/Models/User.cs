using System.Text.Json.Serialization;

namespace BookLibraryAPI.Models;

public class User
{
   
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    [JsonIgnore]
    public List<Book> Books { get; set; } = new List<Book>();
}