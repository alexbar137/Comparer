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
    public class ParserLocatorTests
    {
        string validSDLXliff;
        string validMXLiff;
        string invalidName;
        string noExtenstion;
        ParserLocator locator;

        [TestInitialize()]
        public void StartUp()
        {
            validSDLXliff = @"d:\Рабочее\SVN\37617\32\Project\en-US\Localizable.strings.sdlxliff";
            validMXLiff = @"c:\Users\barabash\Desktop\Удалить\joined-P603733-J37-38-40-42-en_us-ru-T.mxliff";
            invalidName = @"first.doc";
            noExtenstion = "first";
            locator = new ParserLocator();
        }

        [TestMethod()]
        public void GetParserTest_SDLXliff()
        {
            IParser parser = locator.GetParser(validSDLXliff);
            Assert.IsInstanceOfType(parser, typeof(SDLParser));
        }

        [TestMethod()]
        public void GetParserTest_Mxliff()
        {
            IParser parser = locator.GetParser(validMXLiff);
            Assert.IsInstanceOfType(parser, typeof(XlfParser));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void GetParserTest_invalid()
        {
            IParser parser = locator.GetParser(invalidName);
            //Assert.IsInstanceOfType(parser, typeof(XlfParser));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void GetParserTest_noExtension()
        {
            IParser parser = locator.GetParser(noExtenstion);
            //Assert.IsInstanceOfType(parser, typeof(XlfParser));
        }
    }
}