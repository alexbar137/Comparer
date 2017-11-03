using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparer.Interfaces;
using DiffPlex;


namespace Comparer.Implementations
{
    public class ChangeTracker : ISegmentComparer
    {
        private List<ISegment> _segments = new List<ISegment>();
        public List<ISegment> Segments
        {
            get
            {
                return _segments;
            }
        }
        ICompareService _service;
        
    
        public ChangeTracker(List<ISegment> segments, ICompareService service)
        {
            _segments = segments as List<ISegment>;
            _service = service;
            CompareSegments();
        }

        public ChangeTracker(List<ISegment> segments)
        {
            _segments = segments;
            _service = new DiffPlexCompareService();
            CompareSegments();
        }



        private void CompareSegments()
        {
            foreach (ISegment segment in Segments)
            {
                segment.CompareResult = _service.Compare(segment);
            }
        }

    }
}
