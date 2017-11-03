using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parsers.Interfaces;

namespace Parsers.Implemenations
{
    public class SDLParser : IParser
    {
        public List<ITUnit> Parse(string filename)
        {
            List<ITUnit> result = new List<ITUnit>();
            var doc = new XliffParser.XlfDocument(filename);
            var xlfFile = doc.Files.Single();
            foreach (var u in xlfFile.TransUnits)
            {
                if (u.Optional.Translate == "no") continue;
                TUnit t = new TUnit();
                t.Id = u.Id;
                t.Source = u.Source;
                t.Target = u.Target;
                result.Add(t);
            }
            return result;
        }
    }
}
