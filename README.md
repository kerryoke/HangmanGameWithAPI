# Hangman Game With API

This console app lets the user play a classic game of Hangman. A word is randomly selected by targeting the HangmanAPI from this project that has a table of words in a database as seed data, ranked by difficulty. The program will ask the user what level of difficulty they would like to play, and then asks for single-letter guesses from the user in order to complete the correct word. The program makes sure that the guess is a single letter and not an invalid character or multiple letters. If a letter is guessed correctly, the letter is displayed in the correct position in the word. If a letter is guessed incorrectly, a corresponding image is shown as the hangman character gets drawn with each successive incorrect guess with a limit of 7 incorrect guesses. At the end of the game, it will ask the user if they want to play again. If they say yes, a new word is chosen and the game continues. If they say no, the user is told how many times they won out of how many games they played. Good luck!

## Notes and instructions:
This program was created using Visual Studio 2022 and .NET 7.0.

Before running, please update the database. To do this:
1. Right click on the solution
2. Select "open in terminal"
3. Type "dotnet ef database update" and hit enter.

Please ensure that both projects are running at the same time. If they are not:
1. Right click on the solution
2. Select "Set Startup Projects"
3. Multiple startup projects
4. Set both projects to "Start" 

The following features have been included in this project:
1. Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
2. Make your application an API
3. Make your application a CRUD API
4. Make your application asynchronous
