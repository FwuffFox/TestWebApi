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

    [HttpGet]
    public IEnumerable<Note> GetAll()
    {
        return _noteRepository.GetNotes();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Note))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        Note? note = await _noteRepository.GetNote(id);
        
        return note is null ? NotFound() : Ok(note);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Note))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] Note note)
    {
        await _noteRepository.AddNote(note);
        _logger.LogInformation("Created new Note with id: {ID}", note.Id);
        return CreatedAtAction(nameof(Get), new {id = note.Id}, note);
    }
    
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        bool isNoteDeleted = await _noteRepository.DeleteNote(id);


        return isNoteDeleted ? NoContent() : NotFound();
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Note note)
    {
        await Task.CompletedTask;
        return Forbid();
        // TODO: Implement Redact Endpoint
    }
}