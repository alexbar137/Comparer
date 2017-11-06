using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parsers.Interfaces;

namespace Parsers.Implemenations
{
    public class TUnit : ITUnit
    {
        public string Id { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
    }
}
