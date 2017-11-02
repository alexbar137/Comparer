using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comparer.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comparer.Interfaces;
using System.Diagnostics;

namespace Comparer.Implementations.Tests
{
    [TestClass()]
    public class ChangeTrackerTests
    {
        Segment EqualTranslations;
        Segment EmptyOriginal;
        Segment Replaced;
        Segment DeletedChar;
        Segment BothEmpty;
        Segment EmptyEdited;
        Segment EditedChar;
        List<Segment> Segments;
        

        [TestInitialize()]
        public void InitializeTest()
        {
            Segments = new List<Segment>();
            EqualTranslations = new Segment("Equal", "Первый", "Первый");
            EmptyOriginal = new Segment("Empty", "", "Первый");
            EmptyEdited = new Segment("Empty", "Первый", "");
            BothEmpty = new Segment("BothEmpty", "", "");
            Replaced = new Segment("Replaced", "Первый", "Второй");
            DeletedChar = new Segment("Edited", "Первый", "Перый");
            EditedChar = new Segment("Edited", "Первый", "Першый");
            
        }

        [TestMethod]
        public void ChangeTracker_NoDiffBlocks_Equal()
        {
            Segments.Add(EqualTranslations);
            ChangeTracker c = new ChangeTracker(Segments);
            IDiffBlock t = c.Segments.FirstOrDefault().CompareResult.FirstOrDefault();
            Assert.AreEqual(null, t);
        }

        [TestMethod]
        public void ChangeTracker_0DeleteCount_EmptyOriginal()
        {
            Segments.Add(EmptyOriginal);
            ChangeTracker c = new ChangeTracker(Segments);
            int t = c.Segments.FirstOrDefault().CompareResult.FirstOrDefault().DeleteCount;
            Assert.AreEqual(0, t);
        }

        [TestMethod]
        public void ChangeTracker_6DeleteCount_EmptyEdited()
        {
            Segments.Add(EmptyEdited);
            ChangeTracker c = new ChangeTracker(Segments);
            int t = c.Segments.FirstOrDefault().CompareResult.FirstOrDefault().DeleteCount;
            Assert.AreEqual(6, t);
        }

        [TestMethod]
        public void ChangeTracker_6InsertCount_EmptyOriginal()
        {
            Segments.Add(EmptyOriginal);
            ChangeTracker c = new ChangeTracker(Segments);
            int t = c.Segments.FirstOrDefault().CompareResult.FirstOrDefault().InsertCount;
            Assert.AreEqual(6, t);
        }
    }
}