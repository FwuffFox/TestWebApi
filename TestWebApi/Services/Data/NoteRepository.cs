using Microsoft.EntityFrameworkCore;
using TestWebApi.Models;

namespace TestWebApi.Services.Data;

public class NoteRepository
{
    private readonly NotesContext _dbContext;

    public NoteRepository(NotesContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Note> GetNotes() => _dbContext.Notes.AsEnumerable();

    public async Task<Note?> GetNote(int id) => 
        await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == id);

    public async Task AddNote(Note note)
    {
        await _dbContext.Notes.AddAsync(note);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteNote(int id)
    {
        Note? noteToDelete = await GetNote(id);
        if (noteToDelete == null)
            return false;
        
        _dbContext.Notes.Remove(noteToDelete);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}