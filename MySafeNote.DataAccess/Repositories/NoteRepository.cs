using MySafeNote.Core;
using MySafeNote.Core.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MySafeNote.DataAccess.Repositories
{
    public class NoteRepository : EfRepository<Note>, INoteRepository
    {
        public NoteRepository(DataContext context) : base(context)
        {
        }
    }
}
