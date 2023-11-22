using TestWebApi.Models;

namespace TestWebApi.Services.Data;

public class NoteRepository
{
    private readonly List<Note> _notes = new(10)
    {
        new () { Id = 0, TimeOfCreation = DateTime.Now },
        new () { Id = 1, Name = "Second", TimeOfCreation = DateTime.Now },
        new () { Id = 2, TimeOfCreation = DateTime.Now },
        new () { Id = 3, TimeOfCreation = DateTime.Now },
    };

    public IEnumerable<Note> GetNotes() => _notes.AsEnumerable();

    public Note? GetNote(int id) => _notes.FirstOrDefault(note => note.Id == id);

    public void AddNote(Note note) => _notes.Add(note);
}