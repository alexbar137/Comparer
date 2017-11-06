using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparer.Interfaces;
using Parsers.Interfaces;

namespace Mapper.Interfaces
{
    public interface IMapper
    {
        List<ISegment> Map(List<ITUnit> source, List<ITUnit> target);
    }
}
