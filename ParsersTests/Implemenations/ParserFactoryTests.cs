using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parsers.Implemenations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parsers.Interfaces;

namespace Parsers.Implemenations.Tests
{
    

    [TestClass()]
    public class ParserFactoryTests
    {
        string mxliff;
        string sdlxliff;
        string mxliffJoined;
        IParser ParserFactory;
        

        [TestInitialize()]
        public void Startup()
        {
            mxliff = @"TestFiles/originalTranslation.mxliff";
            sdlxliff = @"TestFiles/originalTranslation.sdlxliff";
            mxliffJoined = @"TestFiles/joined.mxliff";
            ParserFactory = new ParserFactory();
        }

        [TestMethod()]
        public void ParseTest_mxliff_targetexists()
        {
            List<ITUnit> res = ParserFactory.Parse(mxliff);
            Assert.IsNotNull(res.FirstOrDefault().Target);
        }

        [TestMethod()]
        public void ParseTest_sdlxliff_targetexists()
        {
            List<ITUnit> res = ParserFactory.Parse(sdlxliff);
            Assert.IsNotNull(res.FirstOrDefault().Target);
        }

        [TestMethod()]
        public void ParseTest_mxliff_joined_targetexists()
        {
            List<ITUnit> res = ParserFactory.Parse(mxliffJoined);
            Assert.IsNotNull(res.FirstOrDefault().Target);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod()]
        public void ParseTest_emptyFileName()
        {
            List<ITUnit> res = ParserFactory.Parse("");
        }
    }
}