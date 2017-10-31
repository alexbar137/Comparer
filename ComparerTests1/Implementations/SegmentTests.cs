using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comparer.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparer.Implementations.Tests
{
    [TestClass()]
    public class SegmentTests
    {
        Segment EqualTranslations;
        Segment EmptyOriginal;
        Segment Replaced;
        Segment DeletedChar;
        Segment BothEmpty;
        Segment EmptyEdited;
        Segment EditedChar;


        [TestInitialize()]
        public void InitializeTest()
        {
            EqualTranslations = new Segment("Equal", "Первый", "Первый");
            EmptyOriginal = new Segment("Empty", "", "Первый");
            EmptyEdited = new Segment("Empty", "Первый", "");
            BothEmpty = new Segment("BothEmpty", "", "");
            Replaced = new Segment("Replaced", "Первый", "Второй");
            DeletedChar = new Segment("Edited", "Первый", "Перый");
            EditedChar = new Segment("Edited", "Первый", "Першый");

        }

        [TestMethod()]
        public void SegmentTest_Similarity_Equal()
        {
            EqualTranslations.CompareResult = new List<Interfaces.IDiffBlock>();                
            EqualTranslations.CompareResult.Add(new DifferenceBlock()
            {
                DeleteCount = 0, InsertCount = 0
            });
            Assert.AreEqual(100, EqualTranslations.Similarity);
        }

        [TestMethod()]
        public void SegmentTest_Similarity_EmptyOriginal()
        {
            EmptyOriginal.CompareResult = new List<Interfaces.IDiffBlock>();
            EmptyOriginal.CompareResult.Add(new DifferenceBlock()
            {
                DeleteCount = 0,
                InsertCount = 6
            });
            Assert.AreEqual(0, EmptyOriginal.Similarity);
        }

        [TestMethod()]
        public void SegmentTest_Similarity_EmptyEdited()
        {
            EmptyEdited.CompareResult = new List<Interfaces.IDiffBlock>();
            EmptyEdited.CompareResult.Add(new DifferenceBlock()
            {
                DeleteCount = 0,
                InsertCount = 6
            });
            Assert.AreEqual(0, EmptyEdited.Similarity);
        }

        [TestMethod()]
        public void SegmentTest_Similarity_BothEmpty()
        {
            BothEmpty.CompareResult = new List<Interfaces.IDiffBlock>();
            BothEmpty.CompareResult.Add(new DifferenceBlock()
            {
                DeleteCount = 0,
                InsertCount = 0
            });
            Assert.AreEqual(100, BothEmpty.Similarity);
        }

        [TestMethod()]
        public void SegmentTest_Similarity_Replaced()
        {
            Replaced.CompareResult = new List<Interfaces.IDiffBlock>();
            Replaced.CompareResult.Add(new DifferenceBlock()
            {
                DeleteCount = 6,
                InsertCount = 6
            });
            Assert.AreEqual(0, Replaced.Similarity);
        }

        [TestMethod()]
        public void SegmentTest_Similarity_DeletedChar()
        {
            DeletedChar.CompareResult = new List<Interfaces.IDiffBlock>();
            DeletedChar.CompareResult.Add(new DifferenceBlock()
            {
                DeleteCount = 1,
                InsertCount = 0
            });
            Assert.IsTrue(DeletedChar.Similarity > 90 &&
                DeletedChar.Similarity < 100);
        }

        [TestMethod()]
        public void SegmentTest_Similarity_EditedChar()
        {
            EditedChar.CompareResult = new List<Interfaces.IDiffBlock>();
            EditedChar.CompareResult.Add(new DifferenceBlock()
            {
                DeleteCount = 1,
                InsertCount = 1
            });
            Assert.IsTrue(EditedChar.Similarity > 90 &&
                EditedChar.Similarity < 100);
        }
    }
}
