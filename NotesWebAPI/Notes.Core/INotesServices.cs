using Notes.DB;
using System.Collections.Generic;

namespace Notes.Core
{
    public interface INotesServices
    {
        List<Note> GetNotes();
        Note GetNote(int id);
        Note CreateNote(Note note);
        void EditNote(Note note);
        void DeleteNote(int id);
    }
}
