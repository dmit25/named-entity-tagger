using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NER_SPLRL
{
    class TimeRegexSVK : IRegex
    {
        public override string TagLine(string line)
        {
            string copyLine = line;

            foreach(string regex in patterns)
            {
                MatchCollection matches = Regex.Matches(copyLine, regex, RegexOptions.IgnoreCase);

                foreach (var time in matches)
                {
                    copyLine = copyLine.Replace(time.ToString(), "<[TEMPORALEXP:" + time.ToString() + "]>");
                }
            }

            return copyLine;
        }

        //private string RemoveDoubleTagging(string input)
        //{
        //    bool isClosed = true;

            

        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        if (input[i] == '<' && isClosed)
        //        {

        //            isClosed = false;
        //        }
        //    }

        //    return null;
        //}
    }
}
