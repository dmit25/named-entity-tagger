using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NER_SPLRL
{
    class SlovakLocationTagger : INETagger
    {
        private IRuleBasedMechanism lg;

        public SlovakLocationTagger()
        {
            this.lg = new LocationGazetteerSVK();
            lg.LoadResources(@"E:\Saarland University Courses\software-project\low-resource-languages\WORD LISTS\Slovak\Sk_Cities.txt");
            lg.LoadResources(@"E:\Saarland University Courses\software-project\low-resource-languages\WORD LISTS\Slovak\Sk_Countries.txt");


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
