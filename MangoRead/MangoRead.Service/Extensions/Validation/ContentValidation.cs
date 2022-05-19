using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MangoRead.Service.Extensions.Validation
{
    public static class ContentValidation
    {
        public const string WrongPathPatternException = "Incorrect path pattern. Example: [Manuscript Title]\\Volume #\\Chapter #\\#.[image extension].\r\nBut yours is:";

        public static void ValidatePathToFile(this string input)
        {
            Regex regex = new Regex(@"[\\]Volume \d[\\]Chapter \d[\\]");
            var match = regex.Match(input);

            if (!match.Success)
            {
                throw new ArgumentException(WrongPathPatternException, input);
            }
        }
    }
}
