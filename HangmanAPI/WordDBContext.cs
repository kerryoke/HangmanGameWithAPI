using HangmanAPI.Controllers;
using HangmanAPI.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;

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

        public List<Word> ReadJsonFile()
        {
            using StreamReader streamReader = new(@"WordFile.json");
            var json = streamReader.ReadToEnd();
            List<Word> words = JsonSerializer.Deserialize<List<Word>>(json);
            return words;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var wordsFromJson = ReadJsonFile();
            wordsFromJson.ForEach(word =>
            {
                modelBuilder.Entity<Word>().HasData(word);
            });
            base.OnModelCreating(modelBuilder);
        }
    }

}
