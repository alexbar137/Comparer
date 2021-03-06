﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparer.Interfaces
{
    public interface ISegment
    {
        string Source { get; set; }
        string OriginalTranslation { get; set; }
        string EditedTranslation { get; set; }
        List<IDiffBlock> CompareResult { get; set; }
        double Similarity { get; set; }
    }
}
