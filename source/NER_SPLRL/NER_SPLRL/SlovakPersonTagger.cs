using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NER_SPLRL
{
    class SlovakPersonTagger: INETagger
    {

        private IRuleBasedMechanism lg;

        public SlovakPersonTagger()
        {
            this.lg = new PersonGazetteerSVK();
            lg.LoadResources(@"E:\Saarland University Courses\software-project\low-resource-languages\WORD LISTS\Slovak\Sk_FE_names.txt");
            lg.LoadResources(@"E:\Saarland University Courses\software-project\low-resource-languages\WORD LISTS\Slovak\Sk_MA_names.txt");


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
