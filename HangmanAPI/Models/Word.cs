using System.Text.Json.Serialization;

namespace HangmanAPI.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Difficulty { get; set; }
    }
}
