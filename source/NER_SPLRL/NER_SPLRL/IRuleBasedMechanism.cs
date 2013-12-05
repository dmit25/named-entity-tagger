using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NER_SPLRL
{
    /// <summary>
    /// This interface represents basic rule-based approach to tag entities
    /// </summary>
    public interface IRuleBasedMechanism
    {
        /// <summary>
        /// Adds one item to gazetteer
        /// </summary>
        /// <param name="item">item to be added</param>
        /// <returns>true | false</returns>
        bool AddItem(string item);

        /// <summary>
        /// Removes one item from gazetteer
        /// </summary>
        /// <param name="item">item to be removed</param>
        /// <returns>true | false</returns>
        bool RemoveItem(string item);

        /// <summary>
        /// Loads multiple items to gazetteer from file
        /// </summary>
        /// <param name="fileName">path to the file</param>
        void LoadResources(string fileName);

        /// <summary>
        /// Returns collection of gazetteer
        /// </summary>
        /// <returns>IEnumerable collection</returns>
        IEnumerable<string> ShowAll();

        /// <summary>
        /// Tags one line of text
        /// </summary>
        /// <param name="line">line to be tagged</param>
        /// <returns>tagged line</returns>
        string TagLine(string line);

        /// <summary>
        /// Exports gazetteer to file
        /// </summary>
        /// <param name="fileName">path to the file</param>
        void ExportToFile(string fileName);
    }
}
