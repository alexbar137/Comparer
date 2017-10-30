using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparer.Interfaces;
using DiffPlex.Model;

namespace Comparer.Implementations
{
    public class ProcessedSegment : IProcessedSegment
    {
        private DiffResult _comparisonResult;
        public DiffResult ComparisonResult
        {
            get
            {
                return _comparisonResult;
            }
            set
            {
                _comparisonResult = value;
                double deletePersantage = (Convert.ToDouble(_comparisonResult.DiffBlocks.Sum(s => s.DeleteCountA)))
                                                 / OriginalTranslation.Length * 100;
                double insertPersentage = (Convert.ToDouble(_comparisonResult.DiffBlocks.Sum(s => s.InsertCountB)))
                                                 / EditedTranslation.Length * 100;
                Similarity = 100 - deletePersantage - insertPersentage > 50 ?
                                         100 - deletePersantage - insertPersentage : 0;

            }
        }
        public double Similarity { get; set; }
        public string Source { get; set; }
        public string EditedTranslation { get; set; }
        public string OriginalTranslation { get; set; }

        public ProcessedSegment(ISegment segment)
        {
            Source = segment.Source;
            OriginalTranslation = segment.OriginalTranslation;
            EditedTranslation = segment.EditedTranslation;
        }
    }
}
