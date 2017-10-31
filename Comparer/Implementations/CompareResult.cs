using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparer.Interfaces;

namespace Comparer.Implementations
{
    class CompareResult : ICompareResult
    {
        public List<IDiffBlock> DiffBlocks { get; set; }
    }
}
