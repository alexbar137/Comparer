using SegmentProcessor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparer.Interfaces;
using Parsers.Interfaces;
using Mapper.Interfaces;
using Comparer.Implementations;
using Parsers.Implemenations;
using mp = Mapper.Implementations;

namespace SegmentProcessor
{
    /// <summary>
    /// Proxy class to compare segments
    /// </summary>
    public class Processor : IProcessor
    {
        private ISegmentComparer _comparer;
        private IParser _parser;
        private ICompareService _compareService;
        private IMapper _mapper;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Processor()
        {
            _parser = new ParserFactory();
            _compareService = new DiffPlexCompareService();
            _comparer = new ChangeTracker(_compareService);
            _mapper = new mp.Mapper();

        }
        /// <summary>
        /// Constructor with ICompareService selection
        /// </summary>
        /// <param name="service">Comparison service</param>
        public Processor(ICompareService service)
        {
            _parser = new ParserFactory();
            _comparer = new ChangeTracker(service);
            _mapper = new mp.Mapper();

        }

        /// <summary>
        /// Compare original and edited bilingual files
        /// </summary>
        /// <param name="original">Path to original file</param>
        /// <param name="edited">Path to edited file</param>
        /// <returns></returns>
        public List<ISegment> Compare(string original, string edited)
        {
            List<ITUnit> orig = _parser.Parse(original);
            List<ITUnit> edit = _parser.Parse(edited);
            List<ISegment> segments = _mapper.Map(orig, edit);
            segments = _comparer.CompareSegments(segments);
            return segments;
        }

    }
}
