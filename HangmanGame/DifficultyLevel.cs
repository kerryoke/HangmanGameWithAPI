using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    public class DifficultyLevel
    {
        public static async Task<string> ChooseDifficulty()
        {
            Console.WriteLine("Type '1' for STANDARD difficulty words.");
            Console.WriteLine("Type '2' for HARD difficulty words.");
            Console.WriteLine("Type '3' for ALL words.");

            int difficultyLevel = Convert.ToInt32(Console.ReadLine());
            
            
            switch(difficultyLevel)
            {
                case 1:
                    return await GetWordByDifficulty.GetAllStandard();
                case 2:
                    return await GetWordByDifficulty.GetAllHard();
                case 3:
                    return await GetWordByDifficulty.GetAll();
                default:
                    return await GetWordByDifficulty.GetAll();

                    
                    
                
                    
            }
        }
    }
}
