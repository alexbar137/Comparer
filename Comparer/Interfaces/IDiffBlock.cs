using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparer.Interfaces
{
    public interface IDiffBlock
    {
        int InsertStart { get; set; }
        int InsertCount { get; set; }
        int DeleteStart { get; set; }
        int DeleteCount { get; set; }
    }
}
