using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NER_SPLRL
{
    public abstract class INETagger
    {
        public Hashtable corpus = new Hashtable();
        public IRuleBasedMechanism rbm;
        public int tagsNumber;

        //This method could be called several times to add more than one file to the corpus.
        public void loadCorpus(string fileAddress)
        {

            try
            {
                string text = File.ReadAllText(fileAddress);

                text = " " + text.Replace("\n", "\n ");

                corpus.Add(fileAddress, text);

            }
            catch (IOException)
            {
            }

        }

        public void loadCorpus(Hashtable co)
        {
            this.corpus = co;
        }

        //This method ignores the filename in the parameter. just uses the absolute address.
        public void saveCorpus(string fileAddress)
        {
            foreach (DictionaryEntry item in corpus)
            {

                string name = ((string)item.Key);
                //fileAddress = fileAddress.Substring(0, name.LastIndexOf('\\') + 1) + name + "-tagged.txt";

                System.IO.TextWriter fs = new StreamWriter(fileAddress, false, Encoding.Unicode);

                fs.Write((string)item.Value);


                fs.Close();
            }

        }

        public abstract void tagCorpus();

    }
}
