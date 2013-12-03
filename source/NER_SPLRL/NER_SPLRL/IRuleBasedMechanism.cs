using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NER_SPLRL
{
    public interface IRuleBasedMechanism
    {
        bool AddItem(string item);

        bool RemoveItem(string item);

        void LoadResources(string fileName);

        IEnumerable<string> ShowAll();

        string TagLine(string line);

        void ExportToFile(string fileName);
    }
}
