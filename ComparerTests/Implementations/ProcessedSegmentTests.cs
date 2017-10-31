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

       
    }
}