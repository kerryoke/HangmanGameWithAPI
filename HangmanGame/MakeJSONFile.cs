using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanGame
{
    public class MakeJSONFile
    {
        public static async Task ConvertToJson()
        {
            string json = await GetWordByDifficulty.GetAllForJson();
            File.WriteAllText("C:\\Users\\Ben\\Desktop\\Kerry\\Code Louisville\\WordFile.json", json);



        }
    }
}
