using Comparer.Interfaces;
using Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentProcessor.Interfaces
{
    interface IProcessor
    {
        /// <summary>
        /// Compares original and edited bilingual files.
        /// </summary>
        /// <param name="original">Path to file with original translation</param>
        /// <param name="edited">Path to file with edited translation</param>
        /// <returns>Returns a list of ISegment</returns>
        List<ISegment> Compare(string original, string edited);
    }
}
