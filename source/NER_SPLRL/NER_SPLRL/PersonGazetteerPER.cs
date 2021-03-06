﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NER_SPLRL
{
    class PersonGazetteerPER : IGazetteer
    {

        private const string TAG_START = "<[PERSON:";
        private const string TAG_END = "]>";


        public PersonGazetteerPER(): base()
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

        //            foreach (string person in ItemList)
        //            {

        //                if ((" " + wt[0] + " " ).Contains( " " + person + " "))
        //                {
                                                        
        //                    //wt[1] = "PERSON";

        //                    per = true;
                            
        //                    break;
        //                }
        //            }

        //            if (per)
        //            {
        //                outputLine += TAG_START + wt[0] + TAG_END + " " ;
        //            }
        //            else
        //            {
        //                outputLine += wt[0] + " ";
        //            }
        //        }
        //    }
        //    return outputLine;
        //}

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

                foreach (string person in ItemList)
                {

                    if ((" " + i + " ").Contains(" " + person + " "))
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
