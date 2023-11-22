namespace TestWebApi.Models;

public class Note
{
    public int Id { get; set; }
    public string Name { get; set; } = "Default Name";
    public string Content { get; set; } = "";
    public DateTime TimeOfCreation { get; set; }
}