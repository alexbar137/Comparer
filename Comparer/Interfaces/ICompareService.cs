﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparer.Interfaces
{
    public interface ICompareService
    {
        IEnumerable<IDiffBlock> Compare(ISegment segment);
    }
}
