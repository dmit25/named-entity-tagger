﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NER_SPLRL
{
    /// <summary>
    /// This class represents gazetteer's approach
    /// </summary>
    public abstract class IGazetteer : IRuleBasedMechanism
    {
        protected ISet<string> ItemList { get; set; }

        public IGazetteer()
        {
            ItemList = new HashSet<string>();
        }

        public abstract string TagLine(string line);

        public bool AddItem(string item)
        {
            return ItemList.Add(item);
        }

        public bool RemoveItem(string item)
        {
            return ItemList.Remove(item);
        }

        public void LoadResources(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (sr.Peek() >= 0)
                    ItemList.Add(sr.ReadLine());
            }
        }

        public IEnumerable<string> ShowAll()
        {
            return ItemList;
        }

        public void ExportToFile(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (string item in ItemList)
                    sw.WriteLine(item);
            }
        }
    }
}
