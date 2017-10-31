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
        public List<ISegment> Segments { get; set; }
        ICompareService _service;
        
    
        public ChangeTracker(IEnumerable<ISegment> segments, ICompareService service)
        {
            Segments = segments as List<ISegment>;
            _service = service;
            CompareSegments();
        }

        public ChangeTracker(IEnumerable<ISegment> segments)
        {
            Segments = segments as List<ISegment>;
            _service = new DiffPlexCompareService();
            CompareSegments();
        }



        internal void CompareSegments()
        {
            foreach (ISegment segment in Segments)
            {
                segment.CompareResult = _service.Compare(segment);
            }
        }

    }
}
