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
        private List<IDiffBlock> _compareResult = new List<IDiffBlock>();

        public string EditedTranslation { get; set; }
        public string OriginalTranslation { get; set; }
        public string Source { get; set; }
        public double Similarity { get; set; }

        public List<IDiffBlock> CompareResult
        {
            get
            {
                return _compareResult;
            }
            set
            {
                _compareResult = value;
                CalcSimilarity();
                
            }
        }
       
        public Segment(string source, string original, string edited)
        {
            Source = source;
            OriginalTranslation = original;
            EditedTranslation = edited;
        }

        private void CalcSimilarity()
        {
            if ((String.IsNullOrEmpty(OriginalTranslation) &&
                    !String.IsNullOrEmpty(EditedTranslation)) ||
                    (!String.IsNullOrEmpty(OriginalTranslation) &&
                    String.IsNullOrEmpty(EditedTranslation)))
            {
                Similarity = 0;
            }

            else
            {
                if (String.IsNullOrEmpty(OriginalTranslation) &&
                    String.IsNullOrEmpty(EditedTranslation))
                {
                    Similarity = 100;
                }
                else
                {
                    double deletePersentage = (double)CompareResult.Sum(s => s.DeleteCount) / OriginalTranslation.Length * 100;
                    double insertPersentage = (double)CompareResult.Sum(s => s.InsertCount) / EditedTranslation.Length * 100;
                    Similarity = 100 - deletePersentage - insertPersentage;
                    Similarity = Similarity > 50 ? Similarity : 0;
                }
            }
        }
    }
}
