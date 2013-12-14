using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NER_SPLRL
{
    class TimeRegex: IRegex
    {

       
        public TimeRegex():base()
        {
            
        }

        public override string TagLine(string line)
        {
            // copy of input parameter (line)
            string copyLine = line;

            List<string> results = new List<string>();

            bool matchWholePattern = true; //todoooooooooo

            foreach (string p in patterns)
            {
                try
                {

                    foreach (Match match in Regex.Matches(line, p, RegexOptions.IgnoreCase))
                    {
                        if (matchWholePattern)
                        {
                            results.Add(match.Value);
                        }
                        else
                        {

                            if (match.Groups["value"].Value != "")
                                results.Add(match.Groups["value"].Value);
                            if (match.Groups["value1"].Value != "")
                                results.Add(match.Groups["value1"].Value);
                            if (match.Groups["value2"].Value != "")
                                results.Add(match.Groups["value2"].Value);
                            if (match.Groups["value3"].Value != "")
                                results.Add(match.Groups["value3"].Value);
                            if (match.Groups["value4"].Value != "")
                                results.Add(match.Groups["value4"].Value);
                            if (match.Groups["value5"].Value != "")
                                results.Add(match.Groups["value5"].Value);
                            if (match.Groups["value6"].Value != "")
                                results.Add(match.Groups["value6"].Value);
                            if (match.Groups["value7"].Value != "")
                                results.Add(match.Groups["value7"].Value);
                            if (match.Groups["value8"].Value != "")
                                results.Add(match.Groups["value8"].Value);
                            if (match.Groups["value9"].Value != "")
                                results.Add(match.Groups["value9"].Value);
                            //input = input.Replace(match.Value, "</" + match.Value + "/>");
                        }
                    }
                }
                catch (Exception edd)
                {
                    MessageBox.Show(edd.Message);
                }
            }

            foreach (string item in results)
            {

                //may not contain digit
                if (!matchWholePattern)
                {
                    if (item.Contains("0") ||
                            item.Contains("1") ||
                            item.Contains("2") ||
                            item.Contains("3") ||
                            item.Contains("4") ||
                            item.Contains("5") ||
                            item.Contains("6") ||
                            item.Contains("7") ||
                            item.Contains("8") ||
                            item.Contains("9")
                            )
                    {
                        continue;
                    }

                    //neglect list
                    if ((" " + item + " ").Contains(" ترجمه ") ||
                            (" " + item + " ").Contains(" تاليف ") ||
                            (" " + item + " ").Contains(" موارد زير ") ||
                            (" " + item + " ") == (" هاي ") ||
                            (" " + item + " ") == (" ها ") ||
                            (" " + item + " ") == (" بود ") ||
                            (" " + item + " ") == (" اش ") ||
                            (" " + item + " ") == (" در ") ||
                            (" " + item + " ") == (" ديگر ") ||
                            (" " + item + " ").Contains(" آنجا ") ||
                            (" " + item + " ") == (" كوتاه ") ||

                            (" " + item + " ") == (" اين ") ||
                            (" " + item + " ") == (" آن ") ||
                            (" " + item + " ") == (" همين ") ||
                            (" " + item + " ") == (" همان ") ||

                            (" " + item + " ") == (" همانجا ") ||
                            (" " + item + " ") == (" تعدادي ") ||
                            (" " + item + " ") == (" ديگر ") ||
                            (" " + item + " ").Contains(" نيز ")
                            )
                    {
                        continue;
                    }
                }
                
                if (matchWholePattern)
                {
                    copyLine = copyLine.Replace(item, " <[TEMPORALEXP:" + item.Trim() + "]> ");
                }
                else
                {
                    copyLine = copyLine.Replace(" " + item + " ", " <[TEMPORALEXP:" + item + "]> ");
                }



            }


            return copyLine;
        }

        
    }
}
