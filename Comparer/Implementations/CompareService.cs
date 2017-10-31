using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparer.Interfaces;
using DiffPlex;
using DiffPlex.Model;

namespace Comparer.Implementations
{
    class DiffPlexCompareService : ICompareService
    {

        private ICompareResult _result;
        private Differ _diff;
        private DiffResult _diffResult;

        public ICompareResult Compare(ISegment segment)
        {
            _result = new CompareResult();
            _diff = new Differ();
            _diffResult = _diff.CreateCharacterDiffs(segment.OriginalTranslation, 
                segment.EditedTranslation, false);
            GetDiffBlocks();

            return _result;

        }

        private void GetDiffBlocks ()
        {
            foreach (DiffBlock d in _diffResult.DiffBlocks)
            {
                IDiffBlock diffBlock = new DifferenceBlock();
                diffBlock.DeleteStart = d.DeleteStartA;
                diffBlock.DeleteCount = d.DeleteCountA;
                diffBlock.InsertStart = d.InsertStartB;
                diffBlock.InsertCount = d.InsertCountB;
                _result.DiffBlocks.Add(diffBlock);
            }
        }
    }
}
