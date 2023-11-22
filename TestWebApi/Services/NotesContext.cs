using Microsoft.EntityFrameworkCore;
using TestWebApi.Models;

namespace TestWebApi.Services;

public sealed class NotesContext : DbContext
{
    public DbSet<Note> Notes { get; set; } = null!;

    public NotesContext(DbContextOptions<NotesContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}