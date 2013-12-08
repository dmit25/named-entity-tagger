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
        protected string corpusText = "";
        private string corpusAddress = "";
        private IRuleBasedMechanism rbm;
        private int tagsNumber;

        //This method could be called several times to add more than one file to the corpus.
        public void LoadCorpus(string fileAddress)
        {


            try
            {
                string text = File.ReadAllText(fileAddress);

                text = " " + text.Replace("\n", "\n ");

                corpusText = text;

                fileAddress = corpusAddress; 

            }
            catch (IOException)
            {
            }

        }

        //This method ignores the filename in the parameter. just uses the absolute address.
        public void SaveCorpus(string fileAddress)
        {

            string name = corpusAddress;
                //fileAddress = fileAddress.Substring(0, name.LastIndexOf('\\') + 1) + name + "-tagged.txt";

                System.IO.TextWriter fs = new StreamWriter(fileAddress, false, Encoding.Unicode);

                fs.Write(corpusText);


                fs.Close();
            
        }

        public abstract void TagCorpus();

    }
}
