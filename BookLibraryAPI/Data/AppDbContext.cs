using Microsoft.EntityFrameworkCore;
using BookLibraryAPI.Models;

namespace BookLibraryAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }

    // Configuración adicional de la BD (opcional pero recomendado)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relación: User → Books (uno a muchos)
        modelBuilder.Entity<User>()
            .HasMany(u => u.Books)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
