using System.ComponentModel.DataAnnotations;

namespace TestWebApi.Models;

public class Note
{
    public int Id { get; private set; }
    [Required, MinLength(5)]
    public string Name { get; set; }
    public string Content { get; set; } = "";
    public DateTime TimeOfCreation { get; private set; } = DateTime.UtcNow;
}