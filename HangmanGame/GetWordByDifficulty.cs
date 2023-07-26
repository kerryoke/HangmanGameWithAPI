using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Contracts;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;

namespace HangmanGame
{
    
    public class GetWordByDifficulty
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetAll()
        {
            using HttpResponseMessage response = await client.GetAsync("https://localhost:7033/api/Words");
            response.EnsureSuccessStatusCode();
            List<Word> responseBody = await response.Content.ReadFromJsonAsync<List<Word>>();

            var random = new Random();
            int index = random.Next(responseBody.Count);
            return responseBody[index].Name;
        }

        public static async Task<string> GetAllStandard()
        {
            using HttpResponseMessage response = await client.GetAsync("https://localhost:7033/api/Words/difficulty/standard");
            response.EnsureSuccessStatusCode();
            List<Word> responseBody = await response.Content.ReadFromJsonAsync<List<Word>>();

            var random = new Random();
            int index = random.Next(responseBody.Count);
            return responseBody[index].Name;
        }

        public static async Task<string> GetAllHard()
        {
            using HttpResponseMessage response = await client.GetAsync("https://localhost:7033/api/Words/difficulty/hard");
            response.EnsureSuccessStatusCode();
            List<Word> responseBody = await response.Content.ReadFromJsonAsync<List<Word>>();

            var random = new Random();
            int index = random.Next(responseBody.Count);
            return responseBody[index].Name;
        }

         public static async Task<string> GetAllForJson()
        {
            using HttpResponseMessage response = await client.GetAsync("https://localhost:7033/api/Words");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

    }
}
