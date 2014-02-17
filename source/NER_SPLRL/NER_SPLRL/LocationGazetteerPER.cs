using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace NER_SPLRL
{
    class LocationGazetteerPER : IGazetteer
    {

        private const string TAG_START = "<[LOCATION:";
        private const string TAG_END = "]>";

        
        public LocationGazetteerPER():base()
        {
            
        }

        //tagged input
        //public override string TagLine(string line)
        //{
        //   line = line.Trim();

            //if (line == "")
            //    return "";


        //    string outputLine = "";

        //    string[] del = new string[3];
        //    del[0] = "] [";
        //    del[1] = "] ";
        //    del[2] = " [";

        //    string[] sp = line.Split(del, StringSplitOptions.RemoveEmptyEntries);

        //    foreach (string i in sp)
        //    {
        //        if (i.Trim() == "")
        //            continue;

        //        string[] del1 = new string[1];
        //        del1[0] = "/#/";
        //        string[] wt = i.Split(del1, StringSplitOptions.RemoveEmptyEntries);
        //        if (wt[1] != "N_SING")
        //        {
        //            outputLine += wt[0] + " ";
        //            continue;
        //        }
        //        else
        //        {
        //            bool per = false;

        //            foreach (string loc in ItemList)
        //            {

        //                if ((" " + wt[0] + " ").Contains(" " + loc + " "))
        //                {

        //                    //wt[1] = "PERSON";

        //                    per = true;

        //                    break;
        //                }
        //            }

        //            if (per)
        //            {
        //                outputLine += TAG_START + wt[0] + TAG_END + " ";
        //            }
        //            else
        //            {
        //                outputLine += wt[0] + " ";
        //            }
        //        }
        //    }
        //    return outputLine;
        //}

        
        
        //untagged input
        public override string TagLine(string line)
        {
            line = line.Trim();

            if (line == "")
                return "";


            string outputLine = "";


            string[] sp = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (string i in sp)
            {
                if (i.Trim() == "")
                    continue;

                bool per = false;

                foreach (string loc in ItemList)
                {

                    if ((" " + i + " ").Contains(" " + loc + " "))
                    {

                        per = true;

                        break;
                    }
                }

                if (per)
                {
                    outputLine += TAG_START + i + TAG_END + " ";
                }
                else
                {
                    outputLine += i + " ";
                }

            }
            return outputLine;
        }

    }
}
