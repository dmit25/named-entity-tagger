using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NER_SPLRL
{
    public class PersianLocationTagger: INETagger
    {
        public LocationGazetteer lg;

        public PersianLocationTagger()
        {
            this.lg = new LocationGazetteer();
            lg.LoadResources(@"E:\Saarland University Courses\software-project\low-resource-languages\WORD LISTS\Persian\cities.txt");
            lg.LoadResources(@"E:\Saarland University Courses\software-project\low-resource-languages\WORD LISTS\Persian\countries.txt");


        }

        public override void tagCorpus()
        {
            Hashtable taggedht = new Hashtable();

            foreach (DictionaryEntry it in corpus)
            {
                string filetext = (string)it.Value;
                string taggedtext = "";

                string[] ftar = filetext.Split("\n".ToCharArray(), StringSplitOptions.None);

                foreach(string el in ftar)
                {
                     taggedtext += lg.TagLinePersian(el) + "\n";
                }

                taggedht.Add(it.Key, filetext);
               
            }
            corpus = taggedht;
          
        }

    }
}
