using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparer.Interfaces;
using DiffPlex;


namespace Comparer.Implementations
{
    class ChangeTracker : ISegmentComparer
    {
        protected IEnumerable<ISegment> Segments { get; set; }
        protected IEnumerable<IProcessedSegment> ResultingSegments { get; set; }
    
        public ChangeTracker(IEnumerable<ISegment> segments)
        {
            Segments = segments;
        }



        public IEnumerable<IProcessedSegment> CompareSegments(IEnumerable<ISegment> segments)
        {
            foreach (ISegment segment in segments)
            {
                IProcessedSegment newSegment = new ProcessedSegment(segment);
                Differ diff = new Differ();
                newSegment.ComparisonResult = diff.CreateCharacterDiffs(segment.OriginalTranslation,
                                                    segment.EditedTranslation, false);

            }

            return ResultingSegments;
        }

    }
}
