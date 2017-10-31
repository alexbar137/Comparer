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
        private List<IDiffBlock> _compareResult;

        public string EditedTranslation { get; set; }
        public string OriginalTranslation { get; set; }
        public string Source { get; set; }
        public List<IDiffBlock> CompareResult
        {
            get
            {
                return _compareResult;
            }
            set
            {
                _compareResult = value;
                if ((EditedTranslation.Length == 0 &&
                    OriginalTranslation.Length != 0) ||
                    (EditedTranslation.Length != 0 &&
                    OriginalTranslation.Length == 0
                    ))
                {
                    Similarity = 0;
                }
                else if(EditedTranslation.Length == 0 ||
                    OriginalTranslation.Length == 0)
                {
                    Similarity = 100;
                }
                else
                {
                    double deletePersentage =
                           Convert.ToDouble(_compareResult.Sum(s => s.DeleteCount)) /
                           OriginalTranslation.Length * 100;
                    double insertPersentage =
                           Convert.ToDouble(_compareResult.Sum(s => s.InsertCount)) /
                           EditedTranslation.Length * 100;
                    Similarity = 100 - deletePersentage - insertPersentage;
                    Similarity = Similarity > 50 ? Similarity : 0;
                }
            }
        }
        public double Similarity { get; set; }

        public Segment(string source, string original, string edited)
        {
            this.Source = source;
            this.OriginalTranslation = original;
            this.EditedTranslation = edited;
        }
    }
}
