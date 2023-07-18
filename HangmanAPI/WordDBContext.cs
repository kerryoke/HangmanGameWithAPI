using HangmanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HangmanAPI
{
    public class WordDBContext : DbContext
    {
        public DbSet<Word> Words { get; set; }
        public string DbPath { get; }
        public WordDBContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "worddb.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
