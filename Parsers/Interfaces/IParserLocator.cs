using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsers.Interfaces
{
    public interface IParserLocator
    {
        IParser GetParser(string filename);
    }
}
