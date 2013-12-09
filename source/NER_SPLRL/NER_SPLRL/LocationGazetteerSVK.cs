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
        // store all locations
        private IList<string> Locations { get; set; }

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


        public LocationGazetteerSVK()
        {
            Locations = new List<string>();
        }

        public bool AddItem(string item)
        {
            if (Locations.Contains(item))
                return false;

            Locations.Add(item);
            return true;
        }

        public bool RemoveItem(string item)
        {
            return Locations.Remove(item);
        }

        public void LoadResources(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0)
                    AddItem(sr.ReadLine());
            }
        }

        public IEnumerable<string> ShowAll()
        {
            return Locations;
        }

        public string TagLine(string line)
        {
            // copy of input parameter (line)
            string copyLine = line;

            foreach (string country in Locations)
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
                        copyLine = copyLine.Replace(foundLocation, "<= " + foundLocation + " =>");
                }
            }

            return copyLine;
        }

        public void ExportToFile(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (string item in Locations)
                    sw.WriteLine(item);
            }
        }
    }
}
