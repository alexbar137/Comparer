using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsers.Interfaces
{
    public interface ITUnit
    {
        string Id { get; set; }
        string Source { get; set; }
        string Target { get; set; } 
    }
}
