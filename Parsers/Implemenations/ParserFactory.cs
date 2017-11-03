using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parsers.Interfaces;

namespace Parsers.Implemenations
{
    public class ParserFactory : IParser
    {
        
        public List<ITUnit> Parse(string filename)
        {
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename", "Укажите имя файла");
            IParserLocator locator = new ParserLocator();
            IParser parcer = locator.GetParser(filename);
            return parcer.Parse(filename);
        }

    }
}
