using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsers.Interfaces
{
    public interface IParser
    {
        List<ITUnit> Parse(string filename);
    }
}
