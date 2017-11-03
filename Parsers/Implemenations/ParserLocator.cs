using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parsers.Interfaces;
using System.IO;
using System.Diagnostics;

namespace Parsers.Implemenations
{
    public class ParserLocator : IParserLocator
    {
        public IParser GetParser(string filename)
        {
            string ext = Path.GetExtension(filename);
            
            switch(ext)
            {
                case ".xliff":
                    Debug.WriteLine("Xliff");
                    return new XlfParser();
                case ".sdlxliff":
                    Debug.WriteLine("sdlXliff");
                    return new SDLParser();
                case ".mxliff":
                    Debug.WriteLine("mxliff");
                    return new XlfParser();
                default:
                    Debug.WriteLine(ext);
                    throw new ArgumentException("Неподдерживаемый формат файла", "filename");
            }
        }
    }
}
