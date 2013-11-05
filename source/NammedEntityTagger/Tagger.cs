using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NamedEntityTagger
{
    public class Tagger
    {

        public Tagger()
        {
            corpus = new Hashtable();
        }

        Hashtable corpus;

        public Hashtable Corpus
        {
            get { return corpus; }
            set { corpus = value; }
        }

        public void byGazeteer(List<string> words, string tagname)
        {
            Hashtable taggedht = new Hashtable();

            foreach (DictionaryEntry it in Corpus)
            {
                string filetext = (string)it.Value;

                foreach (string item in words)
                {
                    filetext = filetext.Replace(" " + item + " ", " <[" + tagname + ":" + item + "]> ");
                }

                taggedht.Add(it.Key, filetext);

                //progressBar1.Value++;
            }

            Corpus = taggedht;


        }

        public void byRegular(List<string> patterns, string tagname)
        {

            Hashtable taggedht = new Hashtable();

            foreach (DictionaryEntry it in Corpus)
            {
                string filetext = (string)it.Value;

                List<string> results = new List<string>();

                foreach (string p in patterns)
                {
                    try
                    {

                        foreach (Match match in Regex.Matches(filetext, p, RegexOptions.IgnoreCase))
                        {
                            if (filetext.Contains(" اين " + match.Value + " ") ||
                                filetext.Contains(" آن " + match.Value + " ") ||
                                filetext.Contains(" همين " + match.Value + " ") ||
                                filetext.Contains(" همان " + match.Value + " ") ||
                                filetext.Contains(" تعدادي " + match.Value + " ")
                                )
                            {
                                continue;
                            }




                            results.Add(match.Value);

                        }
                    }
                    catch (Exception edd)
                    {
                        //MessageBox.Show(edd.Message);
                    }
                }

                foreach (string item in results)
                {


                    filetext = filetext.Replace(item, " <[" + tagname + ":" + item.Trim() + "]> ");

                }

                taggedht.Add(it.Key, filetext);

                //progressBar1.Value++;
            }

            Corpus = taggedht;

        }



    }
}
