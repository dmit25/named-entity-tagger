using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NER_SPLRL
{
    class PersianPersonTagger: INETagger
    {
        private IRuleBasedMechanism lg;

        public PersianPersonTagger()
        {
            this.lg = new PersonGazetteerPER();
            lg.LoadResources(@"E:\Saarland University Courses\software-project\low-resource-languages\WORD LISTS\Persian\person names-pruned.txt");
            
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

            corpusText = JoinTwoTags(corpusText);
        }

        private string JoinTwoTags(string input)
        {
            return input.Replace("]> <[PERSON:", " ");
        }

    }
}
