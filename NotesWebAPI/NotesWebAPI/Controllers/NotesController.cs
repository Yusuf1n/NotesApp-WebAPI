using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notes.Core;
using Notes.DB;

namespace NotesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly ILogger<NotesController> _logger;
        private INotesServices _notesServices;

        public NotesController(ILogger<NotesController> logger, INotesServices notesServices)
        {
            _logger = logger;
            _notesServices = notesServices;
        }

        // GET - Get all notes
        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_notesServices.GetNotes());
        }

        // GET - Get a specific note
        [HttpGet("{id}", Name = "GetNote")]
        public IActionResult GetNote(int id)
        {  
            return Ok(_notesServices.GetNote(id));
        }


        // POST - Create a note
        [HttpPost]
        public IActionResult CreateNote(Note note)
        {
            var newNote = _notesServices.CreateNote(note);
            return CreatedAtRoute("GetNote", new { newNote.Id }, newNote);
        }

        // PUT - Modifying a note
        [HttpPut]
        public IActionResult EditNote([FromBody] Note note)
        {
            _notesServices.EditNote(note);
            return Ok();
        }

        // DELETE - Delete a specific note
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            _notesServices.DeleteNote(id);
            return Ok();
        }
    }
}
