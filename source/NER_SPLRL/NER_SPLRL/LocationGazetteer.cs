using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace NER_SPLRL
{
    public class LocationGazetteer : IGazetteer
    {
        IList<string> Locations { get; set; }

        public LocationGazetteer()
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
                    Locations.Add(sr.ReadLine());
            }
        }

        public IEnumerable<string> ShowAll()
        {
            return Locations;
        }

        public string TagLine2(string line)
        {
            string copyLine = line;
            HashSet<string> foundCountries = new HashSet<string>();

            foreach (string country in Locations)
            {
                while (line.Length > 0)
                {
                    // removing last letter of country
                    string country2 = country.Substring(0, country.Length - 1);

                    // indexes of start and end of the word
                    int index = line.IndexOf(country2, StringComparison.OrdinalIgnoreCase);

                    // if no word is found
                    if (index == -1)
                    {
                        //sw.WriteLine(output);
                        break;
                    }

                    if (index != 0)
                        if (char.IsLetterOrDigit(line[index - 1]))
                            break;

                    // all possible ending of word
                    int endOfWord = line.IndexOf(" ", index);
                    if (endOfWord == -1)
                        endOfWord = line.IndexOf(".", index);
                    if (endOfWord == -1)
                        endOfWord = line.IndexOf("!", index);
                    if (endOfWord == -1)
                        endOfWord = line.IndexOf("?", index);
                    if (endOfWord == -1)
                        endOfWord = line.IndexOf(",", index);
                    // word is at the end of the line (no character follows)
                    if (endOfWord == -1)
                        endOfWord = line.Length - 1;

                    // get the location word and remove '.' or ',' if any
                    string word = line.Substring(index, endOfWord - index);
                    if (word[word.Length - 1] == '.' || word[word.Length - 1] == ',')
                    {
                        word = word.Remove(word.Length - 1);
                        endOfWord--;
                    }
                    
                    if (LevenshteinDistance.Compute(country, word) < 3)
                    {
                        foundCountries.Add(word);
                    }
                    line = line.Substring(endOfWord + 1);
                }
                line = copyLine;
            }

            foreach (string country in foundCountries)
            {
                copyLine = Regex.Replace(copyLine, String.Format(@"\b{0}\b", country), "<= " + country + " =>");
            }

            return copyLine;
        }

        public string TagLine(string line)
        {
            string copyLine = line;
            HashSet<string> foundCountries = new HashSet<string>();

            foreach (string country in Locations)
            {
                while (line.Length > 0)
                {
                    // removing last letter of country
                    string country2 = country.Substring(0, country.Length - 1);

                    // indexes of start and end of the word
                    int index = line.IndexOf(country2, StringComparison.OrdinalIgnoreCase);

                    

                    // if no word is found
                    if (index == -1)
                    {
                        //sw.WriteLine(output);
                        break;
                    }

                    if (index != 0)
                        if (char.IsLetterOrDigit(line[index - 1]))
                            break;

                    // all possible ending of word
                    int endOfWord = line.IndexOf(" ", index);
                    if (endOfWord == -1)
                        endOfWord = line.IndexOf(".", index);
                    if (endOfWord == -1)
                        endOfWord = line.IndexOf("!", index);
                    if (endOfWord == -1)
                        endOfWord = line.IndexOf("?", index);
                    if (endOfWord == -1)
                        endOfWord = line.IndexOf(",", index);
                    // word is at the end of the line (no character follows)
                    if (endOfWord == -1)
                        endOfWord = line.Length - 1;

                    // get the location word and remove '.' or ',' if any
                    string word = line.Substring(index, endOfWord - index);
                    if (word[word.Length - 1] == '.' || word[word.Length - 1] == ',')
                    {
                        word = word.Remove(word.Length - 1);
                        endOfWord--;
                    }

                    // comparison (non-suatable chars: 'ý', 'é' 'á' 'n')
                    int result = endOfWord - (country2.Length + index);
                    if (result > 0 && result <= 3    &&
                        word[word.Length - 1] != 'ý' &&
                        word[word.Length - 1] != 'á' &&
                        word[word.Length - 1] != 'é' &&
                        word[word.Length - 1] != 'n')
                    {
                        foundCountries.Add(word);
                    }
                    line = line.Substring(endOfWord + 1);
                }
                line = copyLine;
            }

            foreach (string country in foundCountries)
            {
                copyLine = Regex.Replace(copyLine, String.Format(@"\b{0}\b", country), "<= " + country + " =>");
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

