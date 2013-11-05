using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace NammedEntityTagger
{
    public class Parser
    {
        public static string[] Parse(string input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            return Regex.Split(input, "\\s|\\.|\\,",RegexOptions.IgnorePatternWhitespace);
        }

        public static void CountWords(string input, string output)
        {
            if (input == null || output == null)
                throw new ArgumentNullException();

            Dictionary<string, int> words = new Dictionary<string, int>();
            string line;

            using (StreamReader sr = new StreamReader(input))
            {
                while (sr.Peek() >= 0)
                {
                    line = sr.ReadLine();

                    char[] trimChars = { ' ', ',', '.' };
                    line = line.Trim(trimChars);

                    string[] tokens = Parse(line);
                    foreach (string token in tokens)
                    {
                        if (words.ContainsKey(token))
                            words[token]++;
                        else
                            words.Add(token, 1);
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(output))
            {
                foreach (KeyValuePair<string, int> entry in words)
                {
                    sw.WriteLine(entry.Value.ToString() + " " + entry.Key);
                }
            }
        }
    }
}
