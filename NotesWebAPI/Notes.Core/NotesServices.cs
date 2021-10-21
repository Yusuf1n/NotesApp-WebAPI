using Notes.DB;
using System.Collections.Generic;
using System.Linq;

namespace Notes.Core
{
    public class NotesServices : INotesServices
    {
        private AppDBContext _context;
        public NotesServices(AppDBContext context)
        {
            _context = context;
        }

        // GET - Get all notes
        public List<Note> GetNotes()
        {
            return _context.Notes.ToList();
        }

        // GET - Get a specific note
        public Note GetNote(int id)
        {
            return _context.Notes.First(n => n.Id == id);
        }

        // POST - Create a notes
        public Note CreateNote(Note note)
        {
            _context.Add(note);
            _context.SaveChanges();

            return note;
        }

        // PUT - Modifying a note
        public void EditNote(Note note)
        {
            var editedNote = _context.Notes.First(n => n.Id == note.Id);
            editedNote.Value = note.Value;
            _context.SaveChanges();
        }


        // DELETE - Deleting a note
        public void DeleteNote(int id)
        {
            var note = _context.Notes.First(n => n.Id == id);
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }


    }
}
