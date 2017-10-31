using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparer.Interfaces;

namespace Comparer.Implementations
{
    public class DifferenceBlock : IDiffBlock
    {
        public int InsertStart { get; set; }
        public int InsertCount { get; set; }
        public int DeleteStart { get; set; }
        public int DeleteCount { get; set; }
    }
}
