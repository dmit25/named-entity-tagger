using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NER_SPLRL
{
    class PersianTimeTagger: INETagger
    {
        private IRuleBasedMechanism lg;

        public PersianTimeTagger()
        {
            this.lg = new TimeRegex();
            lg.LoadResources(@"E:\Saarland University Courses\software-project\low-resource-languages\regular expressions\Persian\date.txt");

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
