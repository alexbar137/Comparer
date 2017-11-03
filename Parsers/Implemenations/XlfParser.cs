using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parsers.Interfaces;
using fmdev;

namespace Parsers.Implemenations
{
    public class XlfParser : IParser
    {
        private List<ITUnit> result = new List<ITUnit>();
      
        public List<ITUnit> Parse(string filename)
        {
            var doc = new XliffParser.XlfDocument(filename);
            var xlfFiles = doc.Files;
                      
           foreach (var file in xlfFiles)
            {
                foreach (var u in file.TransUnits)
                {
                    TUnit t = new TUnit();
                    t.Id = u.Id;
                    t.Source = u.Source;
                    t.Target = u.Target;
                    result.Add(t);
                }
            }
            
            return result;
        }
    }
}
