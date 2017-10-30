using DiffPlex.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparer.Interfaces
{
    public interface IProcessedSegment : ISegment
    {
        DiffResult ComparisonResult { get; set; }
        double Similarity { get; set; }
    }
}
