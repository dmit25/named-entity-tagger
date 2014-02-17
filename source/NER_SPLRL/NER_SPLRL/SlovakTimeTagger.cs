using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NER_SPLRL
{
    class SlovakTimeTagger : INETagger
    {
        private IRuleBasedMechanism lg;

        public SlovakTimeTagger()
        {
            lg = new TimeRegexSVK();
            lg.LoadResources(@"E:\Saarland University Courses\software-project\low-resource-languages\regular expressions\Slovak\Sk_Time_Regex.txt");
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
