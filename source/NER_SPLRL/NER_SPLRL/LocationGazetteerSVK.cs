using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace NER_SPLRL
{
    class LocationGazetteerSVK : IGazetteer
    {

        private const string TAG_START = "<[LOCATION:";
        private const string TAG_END = "]>";


        // suffixes of adjectives in singular
        private readonly IList<string> ILLEGAL_ENDING_SUFFIXES = new List<string>()
        {
            "ý",
            "í",
            "ého",
            "ému",
            "ým",
            "á",
            "ká",
            "ská",
            "ej",
            "ú",
            "é"
        };


        public LocationGazetteerSVK():base()
        {
            
        }

        public override string TagLine(string line)
        {
            // copy of input parameter (line)
            string copyLine = line;

            foreach (string country in ItemList)
            {
                // create regex
                string exp = MakeRegex(country);

                // match only whole words with all suffixes, which length is less 4
                MatchCollection matches = Regex.Matches(line, exp);

                // eliminate duplicate words
                HashSet<string> set = new HashSet<string>();
                foreach (var foundLocation in matches)
                {
                    set.Add(foundLocation.ToString());
                }

                // tag locations in line
                foreach (var foundLocation in set)
                {
                    //if (!ILLEGAL_ENDING_SUFFIXES.Contains(foundLocation.Substring(country.Length - 1)))
                    if (!IsAdjective(foundLocation))
                        copyLine = copyLine.Replace(foundLocation, TAG_START + foundLocation + TAG_END);
                }
            }

            return copyLine;
        }

        /// <summary>
        /// This method returns regular expression with the given location's name
        /// </summary>
        /// <param name="country">locations name</param>
        /// <returns>regular expression</returns>
        private string MakeRegex(string country)
        {
            string[] split = country.Split(' ');

            // if location name contains only one word
            if (split.Length == 1)
                return "\\b" + country.Substring(0, country.Length - 1) + "(\\w){1,3}\\b";

            StringBuilder result = new StringBuilder();

            // if location name contains multiple words
            foreach (string s in split)
            {
                result.Append("\\b");
                result.Append(s.Substring(0, s.Length - 1));
                result.Append("(\\w){1,3}\\b");
                result.Append(" ");
            }

            result.Remove(result.Length - 1, 1);

            return result.ToString();
        }

        /// <summary>
        /// This method determines if word is an adjective
        /// </summary>
        /// <param name="country">word</param>
        /// <returns>true | false</returns>
        private bool IsAdjective(string country)
        {
            foreach (string end in ILLEGAL_ENDING_SUFFIXES)
            {
                if (country.EndsWith(end))
                    return true;
            }
            
            return false;
        }
    }
}
