using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NER_SPLRL
{
    class PersonGazetteerPER : IGazetteer
    {

        private const string TAG_START = "<[PERSON:";
        private const string TAG_END = "]>";


        public PersonGazetteerPER(): base()
        {
            
        }


        public override string TagLine(string line)
        {
            // copy of input parameter (line)
            string copyLine = line;

            // match only whole words
            foreach (string person in ItemList)
            {
                MatchCollection matches = Regex.Matches(line, String.Format(@"\b{0}\b", person));

                // replace all occurences of found location
                if (matches.Count != 0)
                    copyLine = copyLine.Replace(String.Format(@"\b{0}\b", person), String.Format(@"\b{0}\b",TAG_START + person + TAG_END));
            }

            return copyLine;
        }

    }
}
