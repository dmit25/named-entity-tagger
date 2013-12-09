using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NER_SPLRL
{
    /// <summary>
    /// This interface represents regular expressions' approach 
    /// </summary>
    abstract class IRegex : IRuleBasedMechanism
    {
        protected IList<string> patterns { get; set; }

        public IRegex()
        {
            patterns = new List<string>();
        }

        public abstract string TagLine(string line);


        public bool AddItem(string item)
        {
            if (patterns.Contains(item))
                return false;

            patterns.Add(item);
            return true;
        }

        public bool RemoveItem(string item)
        {
            return patterns.Remove(item);
        }

        public void LoadResources(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0)
                    patterns.Add(sr.ReadLine());
            }
        }

        public IEnumerable<string> ShowAll()
        {
            return patterns;
        }

        public void ExportToFile(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (string item in patterns)
                    sw.WriteLine(item);
            }
        }



    }
}
