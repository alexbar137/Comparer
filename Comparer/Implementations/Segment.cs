using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparer.Interfaces;

namespace Comparer.Implementations
{
    public class Segment : ISegment
    {
        public string EditedTranslation { get; set; }
        public string OriginalTranslation { get; set; }
        public string Source { get; set; }
        public ICompareResult CompareResult { get; set; }

        public Segment(string source, string original, string edited)
        {
            this.Source = source;
            this.OriginalTranslation = original;
            this.EditedTranslation = edited;
        }
    }
}
