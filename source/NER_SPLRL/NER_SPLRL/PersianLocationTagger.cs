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
        private LocationGazetteerPER lg;

        public PersianLocationTagger()
        {
            this.lg = new LocationGazetteerPER();
            lg.LoadResources(@"E:\Saarland University Courses\software-project\low-resource-languages\WORD LISTS\Persian\cities.txt");
            lg.LoadResources(@"E:\Saarland University Courses\software-project\low-resource-languages\WORD LISTS\Persian\countries.txt");


        }

        public override void TagCorpus()
        {
            
            string filetext = corpusText;
            string taggedtext = "";

            string[] ftar = filetext.Split("\n".ToCharArray(), StringSplitOptions.None);

            foreach (string el in ftar)
            {
                taggedtext += lg.TagLine(el) + "\n";
            }

            corpusText = taggedtext;

        }

    }
}
