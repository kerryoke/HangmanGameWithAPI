using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Contracts;
using System.ComponentModel;
using System.Net.Http.Json;

namespace HangmanGame
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to Hangman.");
            Rules.ShowRules();
            Console.WriteLine("Type 'exit' at any time to leave the game.");

            
            
            using HttpResponseMessage response = await client.GetAsync("https://localhost:7033/api/Words");
                response.EnsureSuccessStatusCode();
            List<Word> responseBody = await response.Content.ReadFromJsonAsync<List<Word>>();

            //need to configure this to have different options; standard, hard, all; depending on user selection. 
            //turn this into methods
            string hangmanWord = responseBody.FirstOrDefault().Name;

            List <char> correctCharacters = new List<char>();
            correctCharacters.AddRange(hangmanWord);

            Console.WriteLine();
            //display _ for each letter in the word
            for (int i = 0; i < correctCharacters.Count; i++)
            {
                Console.Write("_ ");
            }
            
            string guess = null;
            List<char> incorrectGuesses = new List<char>();  
            List<char> correctGuesses = new List<char>();
            while (guess != "exit" && incorrectGuesses.Count < 7)
            {
                Console.WriteLine("\n\nGuess a letter:");
                guess = Console.ReadLine().ToLower();

                if (guess.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                int guessLength = guess.Length;
                if (guessLength != 1)
                {
                    Console.WriteLine("Please guess one letter.");
                }
                else
                {
                    //check to see if the guess is a letter
                    char guessAsChar = char.Parse(guess);
                    bool isLetter = char.IsLetter(guessAsChar);
                    if (!isLetter)
                    {
                        Console.WriteLine("Guess must be a letter.");
                    }
                    else
                    {
                        if (correctCharacters.Contains(guessAsChar))
                        {
                            correctGuesses.Add(guessAsChar);
                        }
                        else
                        {
                            incorrectGuesses.Add(guessAsChar);
                        }
                        Console.WriteLine("Letters you have already guessed:");
                        Console.WriteLine(string.Join(", ", incorrectGuesses));

                        //display _ or letter depending on correct guesses
                        string wordInProgress = DisplayWordInProgress.DetermineWordInProgress(correctCharacters, correctGuesses);

                        Display.DisplayHangmanImage(incorrectGuesses);

                        string wordInProgressNoSpaces = wordInProgress.Replace(" ", "");
                        if (wordInProgressNoSpaces == hangmanWord)
                        {
                            Console.WriteLine("Congratulations, you won!");
                            Console.ReadKey();
                            break;
                        }
                    }
                }
                
            }


        }

        
    }
}

