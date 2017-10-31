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
    public class ChangeTrackerTests
    {
        List<ISegment> Segments { get; set; }

        [TestInitialize()]
        public void InitializeTests()
        {
            Segments = new List<ISegment>
            {
                new Segment("Same translation", "Первый", "Первый"),
                new Segment("Empty", "Второй", ""),
                new Segment("Replaced", "Первый", "Второй"),
                new Segment("Edited", "Певый", "Второй")
            };
        }

    }
}