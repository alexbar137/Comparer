using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comparer.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparer.Interfaces;

namespace Comparer.Implementations.Tests
{
    
    [TestClass()]
    public class ProcessedSegmentTests
    {
        ISegment FirstSegment { get; set; }
        [TestInitialize()]
        public void InitializeTest()
        {
            FirstSegment = new Segment("First", "Исходный перевод", "Исправленный перевод");
        }

        [TestMethod()]
        public void ProcessedSegmentConstructor_Source()
        {
            ProcessedSegment ps = new ProcessedSegment(FirstSegment);
            Assert.AreEqual(ps.Source, "First");
        }

        [TestMethod]
        public void ProcessedSegmentConstructor_Original()
        {
            ProcessedSegment ps = new ProcessedSegment(FirstSegment);
            Assert.AreEqual(ps.OriginalTranslation, "Исходный перевод");
        }

        [TestMethod]
        public void ProcessedSegmentConstructor_Target()
        {
            ProcessedSegment ps = new ProcessedSegment(FirstSegment);
            Assert.AreEqual(ps.EditedTranslation, "Исправленный перевод");
        }
    }
}