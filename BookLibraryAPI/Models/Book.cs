using System.Text.Json.Serialization;

namespace BookLibraryAPI.Models;

public class Book
{
    
    public int Id { get; set; }

    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public int Año { get; set; }
    public string ImagenUrl { get; set; } = string.Empty;

    public int Rating { get; set; }
    public string Reseña { get; set; } = string.Empty;

    public int UserId { get; set; }

    [JsonIgnore]
    public User? User { get; set; }
}