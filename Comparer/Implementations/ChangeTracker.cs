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

        ICompareService _service;
        
    
        public ChangeTracker(ICompareService service)
        {
            
            _service = service;
        }

        public ChangeTracker()
        {
           _service = new DiffPlexCompareService();
        }



        public List<ISegment> CompareSegments(List<ISegment> segments)
        {
            foreach (ISegment segment in segments)
            {
                segment.CompareResult = _service.Compare(segment);
            }
            return segments;
        }

    }
}
