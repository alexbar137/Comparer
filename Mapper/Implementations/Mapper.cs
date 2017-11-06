using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparer.Implementations;
using Comparer.Interfaces;
using Mapper.Interfaces;
using Parsers.Interfaces;

namespace Mapper.Implementations
{
    public class Mapper : IMapper
    {
        public int UneditedSegments { get; private set; }
        public int UneditedWordCount { get; private set; }

        public List<ISegment> Map(List<ITUnit> original, List<ITUnit> edited)
        {
            UneditedSegments = 0;
            UneditedWordCount = 0;
            List<ISegment> result = new List<ISegment>();
            foreach (ITUnit originalUnit in original)
            {
                
                string originalTranslation = originalUnit.Target;
                var editedSegment = edited.FirstOrDefault
                    (s => s.Id == originalUnit.Id);
                string editedTranslation = editedSegment != null ? 
                    editedSegment.Target : "n/a";

                if (originalTranslation == editedTranslation)
                {
                    UneditedSegments++;
                    UneditedWordCount += originalTranslation.Length;
                    continue;
                }
                string source = originalUnit.Source;

                Segment segment = new Segment(source, originalTranslation,
                    editedTranslation);
                result.Add(segment);
            }

            var unmappedEdited = edited.Where(s => !original.Any(t => t.Id == s.Id));

            foreach (ITUnit editedUnit in unmappedEdited)
            {
                result.Add(new Segment(editedUnit.Source,
                    "n/a", editedUnit.Target));
            }
            
            return result;
        }


    }
}
