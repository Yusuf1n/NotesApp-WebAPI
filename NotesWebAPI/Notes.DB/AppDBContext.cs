using Microsoft.EntityFrameworkCore;

namespace Notes.DB
{
    public class AppDBContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Notes;Trusted_Connection=True");
        }
    }
}