using Microsoft.AspNetCore.Mvc;
using TestWebApi.Models;
using TestWebApi.Services.Data;

namespace TestWebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
{
    private readonly ILogger<NotesController> _logger;
    private readonly NoteRepository _noteRepository;

    public NotesController(ILogger<NotesController> logger, NoteRepository noteRepository)
    {
        _logger = logger;
        _noteRepository = noteRepository;
    }

    [HttpGet("")]
    public IEnumerable<Note> GetNotes()
    {
        return _noteRepository.GetNotes();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Note))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Note>> GetNoteById([FromRoute] int id)
    {
        Note? note = await _noteRepository.GetNote(id);
        
        if (note is null)
        {
            return NotFound();
        }

        return note;
    }

    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Note>> CreateNote(Note note)
    {
        await _noteRepository.AddNote(note);
        _logger.LogInformation("Created new Note with id: {ID}", note.Id);
        return CreatedAtAction(nameof(GetNoteById), new {id = note.Id}, note);
    }
}