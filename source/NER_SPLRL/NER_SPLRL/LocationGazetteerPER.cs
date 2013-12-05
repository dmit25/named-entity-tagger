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
        // store all locations
        private IList<string> Locations { get; set; }

        public LocationGazetteerPER()
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

            // match only whole words
            foreach (string country in Locations)
            {
                MatchCollection matches = Regex.Matches(line, String.Format(@"\b{0}\b", country));

                // replace all occurences of found location
                if (matches.Count != 0)
                    copyLine = copyLine.Replace(country, "<= " + country + " =>");
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
