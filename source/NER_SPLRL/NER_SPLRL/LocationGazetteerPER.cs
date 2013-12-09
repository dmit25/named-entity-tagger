using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace NER_SPLRL
{
    class LocationGazetteerPER : IGazetteer
    {

        private const string TAG_START = "<[LOCATION:";
        private const string TAG_END = "]>";

        
        public LocationGazetteerPER():base()
        {
            
        }

        
        public override string TagLine(string line)
        {
            // copy of input parameter (line)
            //string copyLine = line;

            // match only whole words
            foreach (string country in ItemList)
            {
                //MatchCollection matches = Regex.Matches(line, String.Format(@"\b{0}\b", country));
                //Regex.Replace(line, String.Format(@"\b{0}\b", country));
                Regex exp = new Regex(String.Format(@"\b{0}\b", country));
                line = exp.Replace(line, TAG_START + country + TAG_END);

                // replace all occurences of found location
                //if (matches.Count != 0)
                //    copyLine = copyLine.Replace(country, TAG_START + country + TAG_END);
            }

            return line;
        }

    }
}
