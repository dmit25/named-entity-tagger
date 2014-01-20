using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NER_SPLRL
{
    class PersonGazetteerSVK : IGazetteer
    {

        private const string TAG_START = "<[PERSON:";
        private const string TAG_END = "]>";

        private readonly IList<string> ILLEGAL_ENDING_SUFFIXES = new List<string>()
        {
            "ý",
            "í",
            "in",
            "ov",
            "Marec"
        };

        public PersonGazetteerSVK(): base()
        {

        }

        public override string TagLine(string line)
        {
            // copy of input parameter (line)
            string copyLine = line;

            foreach (string person in ItemList)
            {
                // match only whole words with all suffixes, which length is less 5
                Regex regex = new Regex(@"\b(?<!:)" + person.Substring(0, person.Length - 1) + @"\w{1,4}(?!])\b");
                MatchCollection matches = regex.Matches(copyLine);

                // eliminate duplicate words
                HashSet<string> set = new HashSet<string>();
                foreach (var foundPersons in matches)
                {
                    set.Add(foundPersons.ToString());
                }

                // tag locations in line
                foreach (var foundPersons in set)
                {
                    if (IsAdjective(foundPersons))
                        continue;

                    // surname prediction
                    int index = line.IndexOf(foundPersons);
                    string surname = line.Substring(index + foundPersons.Length);
                    if (surname.Length > 1)
                    {
                        if (surname[0] == ' ' && char.IsUpper(surname[1]))
                        {
                            surname = Regex.Match(surname, @"^ \b\w+\b").Value;
                            copyLine = copyLine.Replace(foundPersons + surname, TAG_START + foundPersons + surname + TAG_END);
                        }
                        else
                            copyLine = copyLine.Replace(foundPersons, TAG_START + foundPersons + TAG_END);
                    }
                    else
                        copyLine = copyLine.Replace(foundPersons, TAG_START + foundPersons + TAG_END);                    
                }
            }

            return copyLine;
        }

        /// <summary>
        /// This method determines if word is an adjective
        /// </summary>
        /// <param name="person">word</param>
        /// <returns>true | false</returns>
        private bool IsAdjective(string person)
        {
            foreach (string end in ILLEGAL_ENDING_SUFFIXES)
            {
                if (person.EndsWith(end))
                    return true;
            }

            return false;
        }
    }
}
