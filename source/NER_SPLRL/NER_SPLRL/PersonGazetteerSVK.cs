using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NER_SPLRL
{
    class PersonGazetteerSVK : IGazetteer
    {

        private const string TAG_START = "<[PERSON:";
        private const string TAG_END = "]>";


         public PersonGazetteerSVK(): base()
        {

        }

         public override string TagLine(string line)
         {
             return "";
         }

    }
}
