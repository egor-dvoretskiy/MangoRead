using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MangoRead.Service.Extensions.Validation;

namespace MangoRead.Service.Extensions
{
    public static class PathDetermination
    {
        public static (int, int) GetContentNumbers(this string input)
        {
            int volumeNumber = GetNumberByParam("Volume", input);
            int chapterNumber = GetNumberByParam("Chapter", input);

            return (volumeNumber, chapterNumber);
        }

        private static int GetNumberByParam(string param, string input)
        {
            var match = Regex.Match(input, $@"[\\]{param} \d+[\\]");

            if (!match.Success)
            {
                throw new ArgumentException(ContentValidation.WrongPathPatternException, input);
            }

            string matchedString = match.Value;
            string numberString = Regex.Match(matchedString, @"\d+").Value;
            int number = int.Parse(numberString);

            return number;
        }
    }
}
