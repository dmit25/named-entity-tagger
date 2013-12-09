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
                // match only whole words with all suffixes, which length is less 4
                MatchCollection matches = Regex.Matches(line, "\\b" + country.Substring(0, country.Length - 1) + "(\\w){1,3}\\b");

                // eliminate duplicate words
                HashSet<string> set = new HashSet<string>();
                foreach (var foundLocation in matches)
                {
                    set.Add(foundLocation.ToString());
                }

                // tag locations in line
                foreach (var foundLocation in set)
                {
                    if (!ILLEGAL_ENDING_SUFFIXES.Contains(foundLocation.Substring(country.Length - 1)))
                        copyLine = copyLine.Replace(foundLocation, TAG_START + foundLocation + TAG_END);
                }
            }

            return copyLine;
        }

    }
}
